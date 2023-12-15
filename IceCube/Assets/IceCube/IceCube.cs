using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IceCube : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 1;

    public Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = new Vector2(movementSpeed, Rigidbody.velocity.y);
    }
}
