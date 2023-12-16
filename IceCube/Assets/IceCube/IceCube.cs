using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IceCube : MonoBehaviour
{
    [SerializeField]
    GameObject SplittedIceCube;

    [SerializeField]
    Sprite CubeHalfDamaged;

    [SerializeField]
    Sprite CubeFullyDamaged;

    Sprite DamageState = null;
    SpriteRenderer SpriteRenderer;

    public Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnFail()
    {
        SplittedIceCube.SetActive(true);
        SplittedIceCube.transform.position = transform.position + new Vector3(-transform.localScale.x / 2, transform.localScale.y / 2, 0);
        gameObject.SetActive(false);
        FindFirstObjectByType<MinigameManager>().ShowLost();
    }

    public void OnGetDamage()
    {
        if(DamageState == null)
        {
            SpriteRenderer.sprite = CubeHalfDamaged;
            DamageState = CubeHalfDamaged;
            return;
        }

        if (DamageState == CubeHalfDamaged)
        {
            SpriteRenderer.sprite = CubeFullyDamaged;
            DamageState = CubeFullyDamaged;
            return;
        }

        if(DamageState == CubeFullyDamaged)
        {
            FindObjectOfType<MinigameManager>().ShowLost();
            return;
        }
        
    }
}
