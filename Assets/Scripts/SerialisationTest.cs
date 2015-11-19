using Assets.Scripts.Util;
using Newtonsoft.Json;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Models;

namespace Assets.Scripts
{
    public class SerialisationTest : CustomMonoBehaviour
    {
        private const string Path = "Assets/Resources/Data/Agents.json";

        public void Start()
        {
//            using (var fs = new FileStream(Path, FileMode.Create))
//            {
//                using (var writer = new StreamWriter(fs))
//                {
//                    writer.Write(JsonConvert.SerializeObject(testAgents));
//                }
//            }

//            var agentsData = Resources.Load<TextAsset>("Data/Agents");
//
//            Debug.Log(agentsData.text);
//
//            var agents = JsonConvert.DeserializeObject<List<AgentModel>>(agentsData.text);
//
//            Debug.Log(agents.ToString());
        }

        public void ButtonTest()
        {
            Debug.Log("It lives!");
        }
    }
}