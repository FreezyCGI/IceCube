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
    UnityEvent DeathAction;

    [SerializeField]
    float deathTimer = 1;

    float timer = 0;
    bool timerStarted = false;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        TriggerAction.Invoke();
        timerStarted = true;
    }
}
