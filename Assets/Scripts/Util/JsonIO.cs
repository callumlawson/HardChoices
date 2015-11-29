using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class JsonIo
    {
        private const string TemplateNamespace = "Assets.Scripts.EntityTemplates";

        public static void CallMethodWithTemplateTypes(MethodInfo methodToCall)
        {
            CallMethodWithTemplateTypes(null, methodToCall);
        }

        public static void CallMethodWithTemplateTypes(object context, MethodInfo methodToCall)
        {
            var templateTypes = GetTemplateTypes();
            foreach (var templateType in templateTypes)
            {
                var typedUpdateSchemaMethod = methodToCall.MakeGenericMethod(templateType);
                typedUpdateSchemaMethod.Invoke(context, null);
            }
        }

        public static List<T> GetTemplatesFromFile<T>() where T : new()
        {
            var templateJsonString = LoadJson<T>();
            return GetTempaltesFromJson<T>(templateJsonString);
        }

        public static List<T> GetTempaltesFromJson<T>(string json) where T : new()
        {
            if (string.IsNullOrEmpty(json))
            {
                return new List<T>();
            }
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static void SaveJson<T>(string json)
        {
            SaveJson(typeof(T).Name, json);
        }

        public static void SaveObjectAsJsonFile(string fileName, object gameObject)
        {
            var json = JsonConvert.SerializeObject(gameObject, Formatting.Indented, GetSerializerSettings());
            SaveJson(fileName, json);
        }

        public static void SaveJson(string fileName, string json)
        {
            using (var fs = new FileStream(GetPathForFileName(fileName), FileMode.Create))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Write(json);
                }
            }
        }

        public static string LoadJson<T>()
        {
            try
            {
                using (var fs = new FileStream(GetPathForFileName(typeof(T).Name), FileMode.Open))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public static JsonSerializerSettings GetSerializerSettings()
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                DefaultValueHandling = DefaultValueHandling.Populate,
                NullValueHandling = NullValueHandling.Include,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            };

            jsonSettings.Converters.Add(new StringEnumConverter { CamelCaseText = false });

            return jsonSettings;
        }

        private static IEnumerable<Type> GetTemplateTypes()
        {
            var templateTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == TemplateNamespace);
            return templateTypes;
        }

        private static string GetPathForFileName(string fileName)
        {
            return string.Format("{0}/{1}.json", Application.streamingAssetsPath, fileName);
        }
    }
}
