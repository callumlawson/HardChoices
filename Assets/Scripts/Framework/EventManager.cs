using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using MoonSharp.Interpreter;
using Newtonsoft.Json.ObservableSupport;
using UnityEngine;

namespace Assets.Scripts.Framework
{
    class EventManager
    {
        private List<GameEvent> gameEvents;

        public EventManager()
        {
            Script.DefaultOptions.DebugPrint = Debug.Log;
            gameEvents = new List<GameEvent>();
        }

        public void AddGameEvent(GameEvent gameEvent)
        {
            gameEvents.Add(gameEvent);
        }
        //
        //         try
        //            {
        //                luaScriptContext.DoString(luaScript);
        //            }
        //            catch (ScriptRuntimeException ex)
        //            {
        //                Debug.LogError("Doh! An error occured! " + ex.DecoratedMessage);
        //            }
//
//        luaScriptContext = new Script();
//        luaScriptContext.Globals["TriggerEvent"] = (Action<string>)TriggerEvent;
    }
}
