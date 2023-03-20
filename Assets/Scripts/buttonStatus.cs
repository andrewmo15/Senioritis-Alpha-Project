using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonStatus : MonoBehaviour
{
    public buttonTouch pbutton;
    public buttonTouch kbutton;
    public buttonTouch cbutton;

    public GameObject door;
    private Animator animator;

    private string currpass;
    private string password;

    // Start is called before the first frame update
    void Start()
    {
        password = "kpc";
        currpass = "";
        animator = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
                animator.SetTrigger("open");
            }
            else {
                currpass = "";
            }
        }
    }
}
