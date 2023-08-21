using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManger : Singleton<UiManger>
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    
    private HashSet<string> createdButtons = new HashSet<string>();

    public void CreateButtons(List<SopData> sopDataList)
    {
        foreach (SopData sopData in sopDataList)
        {
            foreach (Step step in sopData.GetSteps())
            {
                string stepTitle = step.GetTitle();

                if (!createdButtons.Contains(stepTitle))
                {
                    GameObject button = Instantiate(buttonPrefab, buttonContainer);
                    TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        buttonText.text = stepTitle;
                    }

                    button.GetComponent<Button>().onClick.AddListener(() => HandleButtonClicked(stepTitle));

                    createdButtons.Add(stepTitle);
                }
            }
        }
    }

    private void HandleButtonClicked(string stepTitle)
    {
        EventHandler.TriggerStepSelected(stepTitle);
    }
    
}
