using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    [SerializeField]
    float transportSpeed = 1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        IceCube iceCube = collision.transform.GetComponent<IceCube>();

        Debug.Log(collision.transform.name);

        if (iceCube)
        {
            iceCube.transform.position += transform.right * Time.deltaTime * transportSpeed;
        }
    }
}
