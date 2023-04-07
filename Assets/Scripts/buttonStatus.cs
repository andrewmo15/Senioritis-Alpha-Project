using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonStatus : MonoBehaviour
{
    public buttonTouch pbutton;
    public buttonTouch kbutton;
    public buttonTouch cbutton;
    
    public TextMeshPro status;
    public TextMeshPro passwordText;

    private string currpass;
    private string password;
    private string code;

    // Start is called before the first frame update
    void Start()
    {
        password = "kpc";
        currpass = "";
        status.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        passwordText.SetText(currpass);
        if (pbutton.buttonPressed) {
            currpass += "p";
            pbutton.buttonPressed = false;
        }
        if (kbutton.buttonPressed) {
            currpass += "k";
            kbutton.buttonPressed = false;
        }
        if (cbutton.buttonPressed) {
            currpass += "c";
            cbutton.buttonPressed = false;
        }
        if (currpass.Length == 3) {
            if (currpass == password) {
                currpass = "";
                status.SetText("Correct! " + code);
            }
            else {
                status.SetText("Try Again");
                currpass = "";
            }
        }
    }

    public void setCode(string c) {
        code = c;
    }
}
