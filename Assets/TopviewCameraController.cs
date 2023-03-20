using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopviewCameraController : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        Vector3 newPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.position = newPosition;
    }
}
