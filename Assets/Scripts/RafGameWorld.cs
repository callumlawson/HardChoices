using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Models;
using Assets.Scripts.Util;
using Assets.Scripts.Visualisation;
using JetBrains.Annotations;
using MoonSharp.Interpreter;
using UnityEngine;

/**
Crazy Idea: There is no difference between data templates and instances. 
The game just happens to start with sample instances which can be copied. 
These samples just happen to not be visible to the player.
New instances can also be created.
**/
namespace Assets.Scripts
{
    public class RafGameWorld : CustomMonoBehaviour
    {
        public static RafGameWorld Instance;
        public EventVisualizer EventVisualizer;
        public List<IObjectModel> World;

        private Script luaScriptContext;
        private static readonly MethodInfo LoadGameDataMethod = typeof(RafGameWorld).GetMethod("LoadGameData");

        public void Start()
        {
            SetupLuaScriptContext();
            Instance = this;
            World = new List<IObjectModel>();
            TriggerEvent("Start");
        }

        public void TriggerEvent(string eventName)
        {
            ReloadGameData();
            var eventModel = World.Find(model => model.Name == eventName);
            var gameEvent = eventModel as GameEvent;
            EventVisualizer.Init(gameEvent);
        }

        public void RunScript(string luaScript)
        {
            try
            {
                luaScriptContext.DoString(luaScript);
            }
            catch (ScriptRuntimeException ex)
            {
                Debug.LogError("Doh! An error occured! " + ex.DecoratedMessage);
            }
        }

        private void ReloadGameData()
        {
            World.Clear();
            JsonIo.CallMethodWithModelTypes(this, LoadGameDataMethod);
        }

        public void LoadGameData<T>() where T : ObjectModel<T>, new()
        {
            var objectModels = JsonIo.GetModelsFromFile<T>().Cast<IObjectModel>();
            World.AddRange(objectModels);
        }

        private void SetupLuaScriptContext()
        {
            Script.DefaultOptions.DebugPrint = Debug.Log;
            luaScriptContext = new Script();
            luaScriptContext.Globals["TriggerEvent"] = (Action<string>)TriggerEvent;
        }
    }
}
