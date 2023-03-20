using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSecurity : MonoBehaviour
{
    // Start is called before the first frame update

    private string securityCode = "1234"; // set your preferred default security code here
    [SerializeField] private string customSecurityCode = "";

    private bool isLocked = true;


    void Start()
    {
        if (customSecurityCode != "")
        {
            securityCode = customSecurityCode;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
