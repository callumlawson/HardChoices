using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visualisation
{
    public class EventVisualizer : CustomMonoBehaviour
    {
        public Text EventName;
        public Text EventDescription;
        public GameObject OptionButtonTemplate;

        private List<GameObject> OptionButtons;

        public void Awake()
        {
            OptionButtons = new List<GameObject>();
        }

        public void Init(GameEvent dataSource)
        {
            EventName.text = dataSource.Name;
            EventDescription.text = dataSource.Description;

            foreach (var oldButton in OptionButtons)
            {
                Destroy(oldButton);
            }
            OptionButtons.Clear();
            foreach (var option in dataSource.EventOptions)
            {
                OptionButtons.Add(CreateOptionButton(option));
            }
        }

        private GameObject CreateOptionButton(GameEvent.EventOption option)
        {
            var optionButton = Instantiate(OptionButtonTemplate);
            optionButton.transform.SetParent(transform, false);
            optionButton.GetComponent<EventOptionVisualizer>().Init(option);
            return optionButton;
        }
    }
}
