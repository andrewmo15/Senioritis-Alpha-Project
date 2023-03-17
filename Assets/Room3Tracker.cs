using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Tracker : MonoBehaviour
{
    public static bool room3Start;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            Debug.Log("Chicken entered room 3");
            room3Start = true;
        }
    }
}
