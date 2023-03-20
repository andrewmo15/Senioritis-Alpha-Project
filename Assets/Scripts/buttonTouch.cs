using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTouch : MonoBehaviour
{
    public bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "Chicken") {
            buttonPressed = true;
        }
    }
}
