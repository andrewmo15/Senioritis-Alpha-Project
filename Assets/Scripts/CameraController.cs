using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject chicken;
    private Vector3 positionOffset;
    private Quaternion rotationOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        positionOffset = new Vector3(0,10,-13);
        rotationOffset = Quaternion.Euler(10, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = chicken.transform.position + positionOffset;
        // transform.rotation = chicken.transform.rotation * rotationOffset;
    }
}
