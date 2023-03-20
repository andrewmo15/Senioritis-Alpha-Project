using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonStatus : MonoBehaviour
{
    public buttonTouch pbutton;
    public buttonTouch bbutton;
    public buttonTouch cbutton;

    private string currpass;
    private string password;
    // Start is called before the first frame update
    void Start()
    {
        password = "bpc";
        currpass = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (pbutton.buttonPressed) {
            currpass += "p";
            pbutton.buttonPressed = false;
        }
        if (bbutton.buttonPressed) {
            currpass += "b";
            bbutton.buttonPressed = false;
        }
        if (cbutton.buttonPressed) {
            currpass += "c";
            cbutton.buttonPressed = false;
        }
        if (currpass.Length == 3) {
            if (currpass == password) {
                // open door
                currpass = "";
                Debug.Log("door opened");
            }
            else {
                currpass = "";
            }
        }
    }
}
