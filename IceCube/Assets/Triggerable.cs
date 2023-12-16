using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UI;

public class Triggerable : MonoBehaviour
{
    [SerializeField]
    GameObject cubeParent;

    [SerializeField]
    Text TxtKey;

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
        Animator.SetTrigger("success" + i.ToString());

        if(Step != MaxStep)
        {
            TxtKey.color = Color.white;
        }
    }

    public void OnCubeInArea(int i)
    {
        if (i != Step || Step >= MaxStep) return;

        TxtKey.color = Color.green;
    }

    public void OnCubeFailed(int i)
    {
        if (i != Step || Step >= MaxStep) return;

        Step = MaxStep + 1;
        TxtKey.color = Color.red;
        IceCube.transform.SetParent(cubeParent.transform, true);
        Animator.SetTrigger("fail" + i.ToString());
    }
}
