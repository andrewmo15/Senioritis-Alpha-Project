using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public GameObject chicken;
    public float launchVelocity = 700f;

    private float launchDelayMin = 1f;
    private float launchDelayMax = 5f;
    private Transform tankTop;

    private void Start()
    {
        tankTop = gameObject.transform.GetChild(1);
        
        float launchDelay = Random.Range(launchDelayMin, launchDelayMax);
        Invoke("LaunchProjectile", launchDelay);
    }

    void LaunchProjectile()
    {
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
