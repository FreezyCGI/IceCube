using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void OnStartGameClicked()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void OnCreditsClicked()
    {

    }
}
