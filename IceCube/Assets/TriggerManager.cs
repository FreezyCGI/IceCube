using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    TriggerArea[] TriggerAreas;
    IceCube IceCube;

    // Start is called before the first frame update
    void Start()
    {
        TriggerAreas = FindObjectsOfType<TriggerArea>();
        IceCube = FindObjectOfType<IceCube>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckKey(KeyCode.Space);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CheckKey(KeyCode.D);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CheckKey(KeyCode.A);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            CheckKey(KeyCode.W);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckKey(KeyCode.S);
        }
    }

    void CheckKey(KeyCode keyCode)
    {
        for(int i = 0; i < TriggerAreas.Length; i++)
        {
            if (TriggerAreas[i].InAreaAndRightClicked())
                return;
        }

        IceCube.OnGetDamage();
    }
}
