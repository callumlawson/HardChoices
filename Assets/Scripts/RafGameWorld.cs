using System.Linq;
using System.Reflection;
using Assets.Scripts.Framework;
using Assets.Scripts.Util;
using Assets.Scripts.Visualisation;

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

        private EventManager EventManager;
        private EntityManager entityManager;

        private static readonly MethodInfo LoadGameDataMethod = typeof (RafGameWorld).GetMethod("LoadGameData");

        public void Start()
        {
            Instance = this;
            entityManager = new EntityManager();
            JsonIo.CallMethodWithTemplateTypes(this, LoadGameDataMethod);
        }

        public void LoadGameData<T>() where T : ITemplate, new()
        {
            var templates = JsonIo.GetTemplatesFromFile<T>().Cast<ITemplate>().ToList();
            templates.ForEach(template => entityManager.CreateEntity(template));
        }
    }
}