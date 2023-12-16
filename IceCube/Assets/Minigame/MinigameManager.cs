using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{

    [SerializeField]
    GameObject WinPanel;

    [SerializeField]
    GameObject LosePanel;

    public void ShowWon()
    {
        WinPanel.SetActive(true);
    }

    public void ShowLost()
    {
        LosePanel.SetActive(true);
    }

    public void OnContinueWonClicked()
    {
        WinPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    public void OnContinueLostClicked()
    {
        LosePanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
