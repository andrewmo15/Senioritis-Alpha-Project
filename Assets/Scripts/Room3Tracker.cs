using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room3Tracker : MonoBehaviour
{
    public static bool firing;
    public Text timeText;
    public List<GameObject> zombies = new List<GameObject>();
    public TextMeshPro code3;
    private string code;
    
    private static float timeRemaining;

    private void Start()
    {
        resetTimeRemaining();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            if (timeText == null || !firing) return;
            
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            firing = false;
            code3.SetText(code);
            Destroy(this);
            Destroy(timeText.gameObject);
        }
    }

    public void setCode(string c) {
        code = c;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Chicken")) return;
        
        resetTimeRemaining();
        firing = true;
        foreach (GameObject zombie in zombies)
        {
            zombie.GetComponent<ProjectileLauncher>().startFiring();
        }
    }

    public static void resetTimeRemaining()
    {
        timeRemaining = 15;
    }
    
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = $"Remaining: {minutes:00}:{seconds:00}";
    }
}
