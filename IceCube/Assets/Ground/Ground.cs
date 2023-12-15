using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IceCube iceCube = collision.transform.GetComponent<IceCube>();

        if (iceCube)
        {
            Destroy(iceCube.gameObject);
        }
    }
}
