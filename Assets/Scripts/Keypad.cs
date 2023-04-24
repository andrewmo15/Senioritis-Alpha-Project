using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{
    private string passcode;
    private string password;
    private string error;
    public InputField inputField;
    public GameObject panel;
    public GameObject door;
    public FloorColorChange code1;
    public Room2PasswordController code2;
    public Room3Tracker code3;
    public TextMeshPro code4;

    private float closeAngle = 0f;
    private float smoothTime = 2f;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        passcode = "";
        password = createPassword();
        code1.setCode("" + password[0]);
        code2.setCode("" + password[1]);
        code3.setCode("" + password[2]);
        code4.SetText("" + password[3]);
        error = "Wrong! Try again.";
    }

    // Update is called once per frame
    void Update()
    {
        inputField.text = passcode;
    }

    private string createPassword() {
        int first = Random.Range(0, 10);
        int second = Random.Range(0, 10);
        int third = Random.Range(0, 10);
        int fourth = Random.Range(0, 10);
        return "" + first + second + third + fourth;
    }

    private void passcodeHandler(string num) {
        if (passcode == error) {
            passcode = num;
        } else {
            passcode += num;
        }
    }

    public void oneClick() {
        passcodeHandler("1");
    }
    public void twoClick() {
        passcodeHandler("2");
    }
    public void threeClick() {
        passcodeHandler("3");
    }
    public void fourClick() {
        passcodeHandler("4");
    }
    public void fiveClick() {
        passcodeHandler("5");
    }
    public void sixClick() {
        passcodeHandler("6");
    }
    public void sevenClick() {
        passcodeHandler("7");
    }
    public void eightClick() {
        passcodeHandler("8");
    }
    public void nineClick() {
        passcodeHandler("9");
    }
    public void zeroClick() {
        passcodeHandler("0");
    }
    public void delClick() {
        if (passcode.Length != 0) {
            passcode = passcode.Substring(0, passcode.Length - 1);
        }
    }
    public void enterClick() {
        if (passcode == password) {
            panel.gameObject.SetActive(false);
            targetRotation = Quaternion.Euler(0f, closeAngle, 0f);
            door.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smoothTime);
        } else {
            passcode = error;
        }
    }
    public void exitClick() {
        passcode = "";
        var canvas = panel.gameObject.GetComponent<CanvasGroup>();
        canvas.alpha = 0;
        canvas.interactable = false;
    }
}
