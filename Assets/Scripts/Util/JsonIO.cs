using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class JsonIo
    {
        private const string ModelNamespace = "Assets.Scripts.Models";
        private const string DataFolderPath = "Assets/Resources/Data/";

        public static IEnumerable<Type> GetModelTypes()
        {
            var modelTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == ModelNamespace);
            return modelTypes;
        }

        public static List<T> GetModelsFromFile<T>() where T : ObjectModel<T>, new()
        {
            var modelName = typeof(T).Name;
            var modelJsonString = Resources.Load<TextAsset>(string.Format("Data/{0}", modelName));
            return GetModelsFromString<T>(modelJsonString);
        }

        public static List<T> GetModelsFromString<T>(TextAsset modelJsonString) where T : ObjectModel<T>, new()
        {
            if (modelJsonString == null)
            {
                return new List<T>();
            }
            return JsonConvert.DeserializeObject<List<T>>(modelJsonString.text);
        }

        //Make into save models
        public static void SaveJson<T>(JArray json)
        {
            var modelName = typeof(T).Name;
            using (var fs = new FileStream(DataFolderPath + modelName + ".json", FileMode.Create))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Write(json);
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
    }
}
