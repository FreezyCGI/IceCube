using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TriggerArea : MonoBehaviour
{
    [SerializeField]
    UnityEvent TriggerAction;

    [SerializeField]
    UnityEvent InAreaAction;

    [SerializeField]
    UnityEvent OutAreaAction;

    [SerializeField]
    UnityEvent DeathAction;

    [SerializeField]
    Text TxtKey;

    [SerializeField]
    KeyCode KeyCode;

    [SerializeField]
    float deathTimer = 1;

    float timer = 0;
    bool timerStarted = false;
    bool CubeInArea = false;

    private void Update()
    {
        if(timerStarted && DeathAction != null)
        {
            timer += Time.deltaTime;
        }

        if(timer >= deathTimer)
        {
            timerStarted = false;
            DeathAction?.Invoke();
        }

        if (CubeInArea && Input.GetKeyDown(KeyCode))
        {
            TriggerAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IceCube>())
        {
            CubeInArea = true;
            InAreaAction.Invoke();
            timerStarted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IceCube>())
        {
            CubeInArea = false;
            DeathAction?.Invoke();
            OutAreaAction?.Invoke();
        }
    }

    public bool InAreaAndRightClicked()
    {
        return CubeInArea && Input.GetKey(KeyCode);
    }
}
