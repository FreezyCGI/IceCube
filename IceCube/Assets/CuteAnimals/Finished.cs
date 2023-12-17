using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    [SerializeField]
    GameObject CubeParent;

    [SerializeField]
    GameObject Fireworks;

    public void OnFinished()
    {
        FindFirstObjectByType<MinigameManager>().ShowWon();
        IceCube iceCube = FindFirstObjectByType<IceCube>();
        iceCube.transform.SetParent(CubeParent.transform);
        iceCube.transform.localPosition = Vector3.zero;
        Fireworks.SetActive(true);
    }
}
