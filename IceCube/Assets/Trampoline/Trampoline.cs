using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trampoline : MonoBehaviour
{
    [SerializeField]
    Vector2 JumpForceRight = Vector2.up;

    [SerializeField]
    Vector2 JumpForceWrong = Vector2.up;

    IceCube IceCube;

    private void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();
    }

    private void Update()
    {
        //if (TriggerArea.IsInArea && Input.GetKeyDown(KeyCode.W) && !Completed)
        //{
        //    Completed = true;
        //}
    }

    public void OnTriggerSuccess()
    {      
        IceCube.Rigidbody.velocity = new Vector2(IceCube.Rigidbody.velocity.x, 0);
        IceCube.transform.position = transform.position;
        IceCube.Rigidbody.AddForce(JumpForceRight, ForceMode2D.Impulse);
    }

    public void OnTriggerFailed()
    {      
        IceCube.Rigidbody.velocity = new Vector2(IceCube.Rigidbody.velocity.x, 0);
        IceCube.transform.position = transform.position;
        IceCube.Rigidbody.AddForce(JumpForceWrong, ForceMode2D.Impulse);  
    }
}
