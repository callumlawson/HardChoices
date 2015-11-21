using UnityEditor;
using MoonSharp.Interpreter;
using UnityEngine;

//TODO: use File and Path.
public class EventScriptLoader
{
    [MenuItem("Tools/Load Event Scripts")]
    public static void LoadEventScripts()
    {
        try
        {
            var script = new Script();
            script.Globals["isTrue"] = true;
            script.DoFile("LuaTest");
            if (script.Call(script.Globals["predicate"]).Boolean)
            {
                script.Call(script.Globals["onResolve"]);
            }
        }
        catch (ScriptRuntimeException ex)
        {
            Debug.LogError("Doh! An error occured! " + ex.DecoratedMessage);
        }
    }
}