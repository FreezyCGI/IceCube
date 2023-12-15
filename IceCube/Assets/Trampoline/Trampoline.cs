using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    [SerializeField]
    Vector2 JumpForce = Vector2.up;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IceCube iceCube = collision.transform.GetComponent<IceCube>();

        if (iceCube)
        {
            iceCube.GetComponent<Rigidbody2D>().AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }
}
