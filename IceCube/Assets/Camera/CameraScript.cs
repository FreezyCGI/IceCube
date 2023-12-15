using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    IceCube IceCube;


    // Start is called before the first frame update
    void Start()
    {
        IceCube = FindFirstObjectByType<IceCube>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(IceCube) 
        {
            transform.position = new Vector3(IceCube.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
