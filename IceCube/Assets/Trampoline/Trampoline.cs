using UnityEngine;
using UnityEngine.UI;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    KeyCode KeyCode;

    [SerializeField]
    GameObject cubeParent;

    [SerializeField]
    Text TxtKey;

    Animator Animator;
    IceCube IceCube;

    bool scriptFinished = false;

    private void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void OnCubeSuccess()
    {
        if (scriptFinished) return;

        IceCube.transform.SetParent(cubeParent.transform, true);
        Animator.SetTrigger("jump");
        scriptFinished = true;
    }

    public void OnCubeInArea(int i)
    {
        if (scriptFinished) return;

        TxtKey.color = Color.green;
    }

    public void OnCubeFailed(int i)
    {
        if (scriptFinished) return;

        TxtKey.color = Color.red;
        IceCube.transform.SetParent(cubeParent.transform, true);
        Animator.SetTrigger("fail");
        scriptFinished = true;
    }
}
