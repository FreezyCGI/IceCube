using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IceCube iceCube = collision.GetComponent<IceCube>();

        if (iceCube)
        {
            iceCube.OnFail();
        }
    }
}
