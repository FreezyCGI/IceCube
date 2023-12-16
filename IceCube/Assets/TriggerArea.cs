using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerArea : MonoBehaviour
{
    bool success = false;
    bool triggered = false;
    bool inArea = false;

    [SerializeField]
    Text TxtKey;

    [SerializeField]
    KeyCode KeyCode;

    [SerializeField]
    Trampoline Trampoline;

    private void Update()
    {
        if (triggered)
            return;

        if (Input.GetKeyDown(KeyCode) && inArea)
        {
            triggered = true;
            success = true;
            Trampoline.OnTriggerSuccess();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered)
            return;

        inArea = true;

        IceCube iceCube = collision.GetComponent<IceCube>();
        if (iceCube)
        {
            TxtKey.color = Color.green;       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggered)
            return;

        inArea = false;
        triggered = true;

        IceCube iceCube = collision.GetComponent<IceCube>();
        if (iceCube)
        {           
            if(!success)
            {
                TxtKey.color = Color.red;
                Trampoline.OnTriggerFailed();
            }
        }
    }
}
