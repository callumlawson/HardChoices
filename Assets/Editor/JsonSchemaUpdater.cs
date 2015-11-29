using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using System.Reflection;
using Assets.Scripts.Util;

public class JsonSchemaUpdater
{
    private static readonly MethodInfo UpdateSchemaMethod = typeof(JsonSchemaUpdater).GetMethod("UpdateSchema");
    private const string GuidKeyName = "Guid";

    [MenuItem("Tools/Update JSON Schema")]
    public static void UpdateJsonSchema()
    {
        JsonIo.CallMethodWithTemplateTypes(UpdateSchemaMethod);
    }

    public static void UpdateSchema<T>() where T : new()
    {
        var modelObjects = GetTempaltesWithDefaultIfNone<T>();
        var reJsonedModels = JsonConvert.SerializeObject(modelObjects, Formatting.Indented, JsonIo.GetSerializerSettings());
//        var sanitisedJson = StipOutGuids(reJsonedModels);
        JsonIo.SaveJson<T>(reJsonedModels);
    }

    private static List<T> GetTempaltesWithDefaultIfNone<T>() where T : new()
    {
        var modelObjects = JsonIo.GetTemplatesFromFile<T>();
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