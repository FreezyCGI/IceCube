using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class IceCube : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    GameObject SplittedIceCube;

    public Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFail()
    {
        SplittedIceCube.SetActive(true);
        SplittedIceCube.transform.position = transform.position + new Vector3(-transform.localScale.x / 2, transform.localScale.y / 2, 0);
        gameObject.SetActive(false);
    }
}
