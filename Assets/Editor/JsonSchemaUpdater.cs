using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Converters;

//TODO: use File and Path.
public class JsonSchemaUpdater
{
    private const string ModelNamespace = "Assets.Scripts.Models";
    private const string GuidKeyName = "Guid";
    private const string DataFolderPath = "Assets/Resources/Data/";
    private static readonly MethodInfo UpdateSchemaMethod = typeof (JsonSchemaUpdater).GetMethod("UpdateSchema");

    [MenuItem("Tools/Update JSON Schema")]
    public static void UpdateJsonSchema()
    {
        var modelTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(t => t.GetTypes())
            .Where(t => t.IsClass && t.Namespace == ModelNamespace);

        foreach (var modelType in modelTypes)
        {
            var typedUpdateSchemaMethod = UpdateSchemaMethod.MakeGenericMethod(modelType);
            typedUpdateSchemaMethod.Invoke(null, null);
        }
    }

    public static void UpdateSchema<T>() where T : new()
    {
        var modelName = typeof (T).Name;
        var modelJsonString = Resources.Load<TextAsset>(string.Format("Data/{0}", modelName));
        var modelObjects = GetObjectsFromString<T>(modelJsonString);
        var reJsonedModels = JsonConvert.SerializeObject(modelObjects, Formatting.Indented, GetSerializerSettings());
        var sanitisedJson = StipOutGuids(reJsonedModels);
        WriteUpdatedJson(modelName, sanitisedJson);
    }

    private static List<T> GetObjectsFromString<T>(TextAsset modelJsonString) where T : new()
    {
        if (modelJsonString == null)
        {
            return new List<T> {new T()};
        }
        return JsonConvert.DeserializeObject<List<T>>(modelJsonString.text);
    }

    private static JArray StipOutGuids(string serializedAgents)
    {
        var agentsJsonObject = JArray.Parse(serializedAgents);
        foreach (var jObject in agentsJsonObject.Children<JObject>())
        {
            jObject.Remove(GuidKeyName);
        }
        return agentsJsonObject;
    }

    private static void WriteUpdatedJson(string modelName, JArray sanitisedJson)
    {
        using (var fs = new FileStream(DataFolderPath + modelName + ".json", FileMode.Create))
        {
            using (var writer = new StreamWriter(fs))
            {
                writer.Write(sanitisedJson);
            }
        }
    }

    private static JsonSerializerSettings GetSerializerSettings()
    {
        var jsonSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Include
        };

        jsonSettings.Converters.Add(new StringEnumConverter { CamelCaseText = false });

        return jsonSettings;
    }
}