using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject chicken;
    public GameObject cameraTarget;
    private Vector3 cameraPositionOffset;
    private Quaternion rotationOffset;
    private Transform chickenOffset;
    private float xInit = 0f;
    private float yInit = -1;
    private float zInit = 2;
    
    public float damping = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraPositionOffset = new Vector3(xInit, yInit, zInit);
        rotationOffset = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    { 
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = chicken.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        Quaternion rotation = Quaternion.Euler(0, angle, 0); 
        transform.position = chicken.transform.position - (rotation * cameraPositionOffset);
        cameraTarget.transform.position = chicken.transform.position + (rotation * new Vector3(0, 0, 10));
        transform.LookAt(cameraTarget.transform);
    }
}
