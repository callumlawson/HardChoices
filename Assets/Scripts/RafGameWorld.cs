using Assets.Scripts.Util;
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
        //Setup in editor
        public GameObject UI;

        public static RafGameWorld Instance;

        public void Start()
        {
            Instance = this;
        }

        public void Update()
        {
        }
    }
}
