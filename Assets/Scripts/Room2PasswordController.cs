using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room2PasswordController : MonoBehaviour
{
    private string passcode;
    private string password;
    public InputField inputField;
    public GameObject panel;
    private string code;
    private string error;
    private string correct;
    // Start is called before the first frame update
    void Start()
    {
        password = "kbc";
        error = "Wrong! Try again.";
    }

    // Update is called once per frame
    void Update()
    {
        inputField.text = passcode;
    }

    private void passcodeHandler(string num) {
        if (passcode == error || passcode == correct) {
            passcode = num;
        } else {
            passcode += num;
        }
    }

    public void aClick() {
        passcodeHandler("a");
    }

    public void cClick() {
        passcodeHandler("c");
    }

    public void fClick() {
        passcodeHandler("f");
    }

    public void pClick() {
        passcodeHandler("p");
    }

    public void kClick() {
        passcodeHandler("k");
    }

    public void iClick() {
        passcodeHandler("i");
    }

    public void mClick() {
        passcodeHandler("m");
    }

    public void rClick() {
        passcodeHandler("r");
    }

    public void tClick() {
        passcodeHandler("t");
    }

    public void bClick() {
        passcodeHandler("b");
    }

    public void setCode(string c) {
        code = c;
        correct = "Correct! Code is " + code;
    }

    public void delClick() {
        if (passcode.Length != 0) {
            passcode = passcode.Substring(0, passcode.Length - 1);
        }
    }

    public void enterClick() {
        if (passcode == password) {
            passcode = correct;
        } else {
            passcode = error;
        }
    }

    public void exitClick() {
        passcode = "";
        var canvas = panel.gameObject.GetComponent<CanvasGroup>();
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
}
