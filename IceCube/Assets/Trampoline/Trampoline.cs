using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Trampoline : TriggerableBase
{
    [SerializeField]
    Vector2 JumpForceRight = Vector2.up;

    [SerializeField]
    Vector2 JumpForceWrong = Vector2.up;

    [SerializeField]
    GameObject CubeParent;

    Animator Animator;

    IceCube IceCube;

    private void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();
        Animator = GetComponent<Animator>();
    }

    public override void OnTriggerSuccess()
    {
        IceCube.Rigidbody.velocity = new Vector2(0, 0);
        IceCube.transform.SetParent(CubeParent.transform);
        IceCube.transform.localPosition = Vector3.zero;
        IceCube.Rigidbody.isKinematic = true;
        Animator.SetTrigger("jump");
    }
    public override void OnTriggerFailed()
    {
        IceCube.Rigidbody.velocity = new Vector2(0, 0);
        IceCube.transform.SetParent(CubeParent.transform);
        IceCube.transform.localPosition = Vector3.zero;
        IceCube.Rigidbody.isKinematic = true;
        Animator.SetTrigger("fail");
    }

    public void OnFail()
    {
        IceCube.OnFail();
    }
}
