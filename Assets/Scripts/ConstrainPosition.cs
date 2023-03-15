using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConstrainPosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x > 40 || pos.x < 5 || pos.z > 30 || pos.z < 3)
        {
            Destroy(gameObject);
        }
    }
}
