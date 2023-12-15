using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        IceCube iceCube = collision.transform.GetComponent<IceCube>();

        Debug.Log(collision.transform.name);

        if (iceCube)
        {
            Destroy(iceCube.gameObject);
        }
    }
}
