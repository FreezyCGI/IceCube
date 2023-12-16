using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    [SerializeField]
    UnityEvent TriggerAction;

    [SerializeField]
    UnityEvent InAreaAction;

    [SerializeField]
    UnityEvent DeathAction;

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
        }
    }

    public bool InAreaAndRightClicked()
    {
        return false;
    }
}
