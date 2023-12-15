using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trampoline : MonoBehaviour
{
    [SerializeField]
    Vector2 JumpForceRight = Vector2.up;

    [SerializeField]
    Vector2 JumpForceWrong = Vector2.up;

    [SerializeField]
    TriggerArea TriggerArea;

    [SerializeField]
    Collider2D FailCollider;

    IceCube IceCube;

    bool Completed = false;

    private void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();
    }

    private void Update()
    {
        if (TriggerArea.IsInArea && Input.GetKeyDown(KeyCode.W) && !Completed)
        {
            Completed = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IceCube iceCube = collision.transform.GetComponent<IceCube>();

        if(!iceCube) { return; }

        if(Completed)
        {
            FailCollider.enabled = false;
            IceCube.Rigidbody.velocity = new Vector2(IceCube.Rigidbody.velocity.x, 0);
            IceCube.transform.position = transform.position;
            IceCube.Rigidbody.AddForce(JumpForceRight, ForceMode2D.Impulse);
        }

        if (!Completed)
        {
            Completed = true;
            FailCollider.enabled = false;
            IceCube.Rigidbody.velocity = new Vector2(IceCube.Rigidbody.velocity.x, 0);
            IceCube.transform.position = transform.position;
            IceCube.Rigidbody.AddForce(JumpForceWrong, ForceMode2D.Impulse);
        }
    }
}
