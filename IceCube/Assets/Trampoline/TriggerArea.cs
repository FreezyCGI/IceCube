using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerArea : MonoBehaviour
{
    public bool IsInArea = false;

    [SerializeField]
    Text TxtKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IceCube iceCube = collision.GetComponent<IceCube>();
        if (iceCube)
        {
            TxtKey.color = Color.green;
            IsInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IceCube iceCube = collision.GetComponent<IceCube>();
        if (iceCube)
        {
            TxtKey.color = Color.white;
            IsInArea = false;
        }
    }
}
