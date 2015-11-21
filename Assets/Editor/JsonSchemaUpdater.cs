using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using System.Reflection;
using Assets.Scripts.Util;

public class JsonSchemaUpdater
{
    private const string GuidKeyName = "Guid";

    private static readonly MethodInfo UpdateSchemaMethod = typeof (JsonSchemaUpdater).GetMethod("UpdateSchema");

    [MenuItem("Tools/Update JSON Schema")]
    public static void UpdateJsonSchema()
    {
        var modelTypes = JsonIo.GetModelTypes();
        foreach (var modelType in modelTypes)
        {
            var typedUpdateSchemaMethod = UpdateSchemaMethod.MakeGenericMethod(modelType);
            typedUpdateSchemaMethod.Invoke(null, null);
        }
    }

    public static void UpdateSchema<T>() where T : ObjectModel<T>, new()
    {
        var modelObjects = GetModelsWithDefaultIfNone<T>();
        var reJsonedModels = JsonConvert.SerializeObject(modelObjects, Formatting.Indented, JsonIo.GetSerializerSettings());
        var sanitisedJson = StipOutGuids(reJsonedModels);
        JsonIo.SaveJson<T>(sanitisedJson);
    }

    private static List<T> GetModelsWithDefaultIfNone<T>() where T : ObjectModel<T>, new()
    {
        var modelObjects = JsonIo.GetModelsFromFile<T>();
        if (modelObjects.Count == 0)
        {
            modelObjects = new List<T> {new T()};
        }
        return modelObjects;
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
}