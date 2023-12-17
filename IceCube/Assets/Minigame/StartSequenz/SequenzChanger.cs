using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SequenzChanger : MonoBehaviour
{
    [SerializeField] 
    TMP_Text sequenzText;

    [SerializeField]
    TriggerArea FirstTrigger;

    [SerializeField]
    GameObject StartSequenzPanel;

    public void ChangeText(string text)
    {
        sequenzText.SetText(text);
    }

    public void StartMinigame()
    {
        ChangeText("GO!");
        FirstTrigger.enabled = true;
    }
}
