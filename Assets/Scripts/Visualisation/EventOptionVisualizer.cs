using Assets.Scripts.States;
using Assets.Scripts.Util;
using UnityEngine.UI;

namespace Assets.Scripts.Visualisation
{
    public class EventOptionVisualizer : CustomMonoBehaviour
    {
        public Text TextComponent;
        public Button ButtonComponent;

        public void Init(GameEvent.EventOption dataSource)
        {
            TextComponent.text = dataSource.Description;
            ButtonComponent.onClick.AddListener(() => RafGameWorld.Instance.RunScript(dataSource.Resolution));
        }
    }
}
