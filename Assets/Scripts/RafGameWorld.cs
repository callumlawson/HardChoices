using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Util;
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

        public List<BaseObject> World;

        private static readonly MethodInfo LoadGameDataMethod = typeof(RafGameWorld).GetMethod("LoadGameData");

        public void Start()
        {
            Script.DefaultOptions.DebugPrint = Debug.Log;

            Instance = this;
            World = new List<BaseObject>();
            InitaliseGameWorld();

            RunScriptTest();
        }

        private void RunScriptTest()
        {
            
        }

        private void InitaliseGameWorld()
        {
            var modelTypes = JsonIo.GetModelTypes();
            foreach (var modelType in modelTypes)
            {
                var typedUpdateSchemaMethod = LoadGameDataMethod.MakeGenericMethod(modelType);
                typedUpdateSchemaMethod.Invoke(this, null);
            }
        }

        public void LoadGameData<T>() where T : ObjectModel<T>, new()
        {
            var objectModels = JsonIo.GetModelsFromFile<T>().Cast<BaseObject>();
            World.AddRange(objectModels);
        }
    }
}
