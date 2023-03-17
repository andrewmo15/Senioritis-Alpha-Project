using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public GameObject chicken;
    public float launchVelocity = 700f;
    
    public float timeRemaining = 10;
    public bool firing;

    private float launchDelayMin = 1f;
    private float launchDelayMax = 5f;
    private Transform tankTop;

    private void Start()
    {
        tankTop = gameObject.transform.GetChild(1);
    }
    
    private void Update()
    {
        if (Room3Tracker.room3Start && !firing)
        {
            firing = true;
            timeRemaining = 10;
            Invoke("LaunchProjectile", 1f);
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            firing = false;
            Room3Tracker.room3Start = false;
        }
    }

    void LaunchProjectile()
    {
        if (!firing)
        {
            return;
        }
        tankTop.GetComponent<Renderer>().material.color = Color.red;
        GameObject axe = Instantiate(projectile, transform.position,  
            transform.rotation);
        Vector3 direction = chicken.transform.position - transform.position;
        direction.Normalize();
        axe.GetComponent<Rigidbody>().AddForce(direction * launchVelocity); 
        StartCoroutine(LaunchDelay());
    }

    IEnumerator LaunchDelay()
    {
        float launchDelay = Random.Range(launchDelayMin, launchDelayMax);
        yield return new WaitForSeconds(launchDelay);
        tankTop.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1f);
        Invoke("LaunchProjectile", launchDelay);
    }
}
