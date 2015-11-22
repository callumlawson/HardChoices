using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class JsonIo
    {
        private const string ModelNamespace = "Assets.Scripts.Models";

        public static IEnumerable<Type> GetModelTypes()
        {
            var modelTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && !t.IsNested && t.Namespace == ModelNamespace);
            return modelTypes;
        }

        public static void CallMethodWithModelTypes(System.Object context, MethodInfo methodToCall)
        {
            var modelTypes = GetModelTypes();
            foreach (var modelType in modelTypes)
            {
                var typedUpdateSchemaMethod = methodToCall.MakeGenericMethod(modelType);
                typedUpdateSchemaMethod.Invoke(context, null);
            }
        }

        public static List<T> GetModelsFromFile<T>() where T : ObjectModel<T>, new()
        {
            var modelJsonString = LoadJson<T>();
            return GetModelsFromString<T>(modelJsonString);
        }

        public static List<T> GetModelsFromString<T>(string modelJson) where T : ObjectModel<T>, new()
        {
            if (modelJson == "")
            {
                return new List<T>();
            }
            return JsonConvert.DeserializeObject<List<T>>(modelJson);
        }

        //Make into save models
        public static void SaveJson<T>(JArray json)
        {
            using (var fs = new FileStream(GetPathForModelName(typeof(T).Name), FileMode.Create))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Write(json);
                }
            }
        }

        public static string LoadJson<T>()
        {
            var modelName = typeof(T).Name;
            using (var fs = new FileStream(GetPathForModelName(typeof(T).Name), FileMode.Open))
            {
                using (var reader = new StreamReader(fs))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static JsonSerializerSettings GetSerializerSettings()
        {
            var jsonSettings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Include
            };

            jsonSettings.Converters.Add(new StringEnumConverter { CamelCaseText = false });

            return jsonSettings;
        }

        private static string GetPathForModelName(string modelName)
        {
            return string.Format("{0}/{1}.json", Application.streamingAssetsPath, modelName);
        }
    }
}
