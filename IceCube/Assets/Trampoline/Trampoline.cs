using UnityEngine;
using UnityEngine.UI;

public class Trampoline : TriggerableBase
{
    [SerializeField]
    KeyCode KeyCode;

    [SerializeField]
    TriggerableBase NextTriggerable;

    [SerializeField]
    GameObject cubeParent;

    [SerializeField]
    Text TxtKey;

    Animator Animator;
    IceCube IceCube;

    bool CubeInArea = false;
    bool scriptFinished = false;

    private void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (scriptFinished) return;

        if (CubeInArea && Input.GetKeyDown(KeyCode))
        {
            IceCube.transform.SetParent(cubeParent.transform, true);
            Animator.SetTrigger("jump");
            scriptFinished = true;
        }
    }


    public void Detected(int i)
    {
        CubeInArea = true;
        TxtKey.color = Color.green;
    }

    public void Die(int i)
    {
        if (scriptFinished) return;

        TxtKey.color = Color.red;
        IceCube.transform.SetParent(cubeParent.transform, true);
        Animator.SetTrigger("fail");
        scriptFinished = true;
    }
}
