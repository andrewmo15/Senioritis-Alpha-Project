using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DoorController : MonoBehaviour
{
    public float openAngle = -90f;
    public float closeAngle = 0f;
    public float smoothTime = 2f;
    public InputField securityCodeInput;
    public Text wrongCodeMessage;

    public KeyCode interactKey = KeyCode.E;

    private string securityCode = "845V"; // set your preferred default security code here
    [SerializeField] private string customSecurityCode = "";


    private Quaternion targetRotation;

    private bool isLocked = true;

    private void Start()
    {
        if (customSecurityCode != "")
        {
            securityCode = customSecurityCode;
        }
        
        wrongCodeMessage.enabled = false; // show error message
    }
    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (securityCodeInput.text == securityCode) // input matches security code
            {
                Debug.Log("in 2");
                targetRotation = Quaternion.Euler(0f, closeAngle, 0f);
                isLocked = false;
                wrongCodeMessage.enabled = false; // hide error message
                Destroy(securityCodeInput.gameObject);
            }
            else // input does not match security code
            {
                if (!String.IsNullOrEmpty(securityCodeInput.text))
                {
                    wrongCodeMessage.enabled = true; // show error message
                }
            }
        }

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smoothTime);
    }

}