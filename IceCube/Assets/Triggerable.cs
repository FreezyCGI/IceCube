using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triggerable : MonoBehaviour
{
    [SerializeField]
    GameObject cubeParent;

    [SerializeField]
    List<Text> TxtKeys;

    [SerializeField]
    int MaxStep = 1;
    int Step = 0;

    Animator Animator;
    IceCube IceCube;

    private void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();
        Animator = GetComponent<Animator>();
    }

    public void OnCubeSuccess(int i)
    {
        if (i != Step || Step >= MaxStep) return;

        Step++;
        IceCube.transform.SetParent(cubeParent.transform, true);
        IceCube.transform.localPosition = Vector3.zero;
        Animator.SetTrigger("success" + i.ToString());

        if(Step != MaxStep)
        {
            TxtKeys[i].color = Color.white;
        }
    }

    public void OnCubeInArea(int i)
    {
        if (i != Step || Step >= MaxStep) return;

        TxtKeys[i].color = Color.green;
    }
    public void OnCubeOutOfArea(int i)
    {
        if (i != Step || Step >= MaxStep) return;

        TxtKeys[i].color = Color.white;
    }

    public void OnCubeFailed(int i)
    {
        if (i != Step || Step >= MaxStep) return;

        Step = MaxStep + 1;
        TxtKeys[i].color = Color.red;
        IceCube.transform.SetParent(cubeParent.transform, true);
        Animator.SetTrigger("fail" + i.ToString());
    }
}
