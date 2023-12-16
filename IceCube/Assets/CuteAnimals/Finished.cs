using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    public void OnFinished()
    {
        FindFirstObjectByType<MinigameManager>().ShowWon();
    }
}
