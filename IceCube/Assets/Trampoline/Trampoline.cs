using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Trampoline : TriggerableBase
{
    [SerializeField]
    bool First = false;

    [SerializeField]
    TriggerableBase Next;

    [SerializeField]
    GameObject CubeParent;

    bool keyPressAllowed = false;
    bool CanContinue = false;
    bool Success = false;

    KeyCode? KeyCode = null;

    IceCube IceCube;
    Animator Animator;
    private void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();
        Animator = GetComponent<Animator>();

        if (First)
        {
            OnStart(true);
        }
    }

    private void Update()
    {
        if (KeyCode == null || keyPressAllowed == false)
        {
            return;
        }

        if (Input.GetKeyDown((KeyCode)KeyCode))
        {
            Success = true;
        }

        if (Success && CanContinue)
        {
            ContinueToNextObject(true);
        }
    }
    public override void OnStart(bool success)
    {
        Debug.Log("OnStart");
        IceCube.transform.SetParent(CubeParent.transform);
        IceCube.transform.localPosition = Vector3.zero;

        if(success)
        {
            Animator.SetTrigger("jump");
            TxtKey.color = Color.green;
        }
        else
        {
            Animator.SetTrigger("fail");
            TxtKey.color = Color.red;
        }    
    }

    public void OnAllowKeyPress(KeyCode keyCode)
    {
        //Debug.Log("OnAllowKeyPress");
        //TxtKey.color = Color.green;
        //keyPressAllowed = true;
        //KeyCode = Next.FirstKey;
    }

    public void OnAllowKeyPressLast()
    {
        Debug.Log("OnAllowKeyPressLast");
        if(Next && Next.TxtKey)
            Next.TxtKey.color = Color.green;
        keyPressAllowed = true;
        KeyCode = Next.FirstKey;
    }

    public override void OnCanContinueToNextObject()
    {
        Debug.Log("OnCanContinueToNextObject");
        CanContinue = true;
    }

    public override void ContinueToNextObject(bool success)
    {
        Debug.Log("ContinueToNextObject");
        if(Next)
            Next.OnStart(success);
    }

    public void OnStartFailAnimationNextObject()
    {
        Debug.Log("OnStartFailAnimationNextObject");
        ContinueToNextObject(false);
    }

    public void OnFail()
    {
        IceCube.OnFail();
    }
}
