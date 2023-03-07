using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Assets.Scripts.Interact;

namespace Assets.Scripts.UI
{
    public class ActionListManager : MonoBehaviour
    {
        public List<GameObject> buttons;
        public List<Interactable> interactables;
        public GameObject actionListViewport;
        public GameObject actionList;
        public GameObject button;
        public float startingHeight;
        // Start is called before the first frame update
        void Start()
        {
            buttons = new List<GameObject>();
            interactables = new List<Interactable>();
            actionListViewport = GameObject.Find("ActionListViewport");
            actionList = GameObject.Find("ActionList");
            startingHeight = -32.5f;
            actionList.SetActive(false);
            button = UnityEngine.Resources.Load<GameObject>("Prefabs/UI/Button");
        }

        public void AddAction(Interactable interactable)
        {
            actionList.SetActive(true);
            interactables.Add(interactable);
            UpdateButtons();
        }

        public void RemoveAction(Interactable interactable)
        {
            interactables.Remove(interactable);
            if (interactables.Count == 0)
                actionList.SetActive(false);
            UpdateButtons();
        }

        public void UpdateButtons()
        {
            foreach(GameObject button in buttons)
            {
                Destroy(button);
            }

            buttons.Clear();

            startingHeight = -32.5f;
            foreach (Interactable interactable in interactables)
            {
                GameObject newButton = Instantiate(button, actionListViewport.transform.GetChild(0));
                RectTransform rectTransform = newButton.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector3(0.0f, startingHeight, 0.0f);
                UnityAction action = new UnityAction(interactable.Interact);
                newButton.GetComponent<Button>().onClick.AddListener(action);
                newButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = interactable.message;
                buttons.Add(newButton);
                startingHeight -= 75.0f;
            }
        }
    }
}