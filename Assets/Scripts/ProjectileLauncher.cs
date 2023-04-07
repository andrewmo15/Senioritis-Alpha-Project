using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public GameObject chicken;
    public AudioClip currentClip;
    public AudioSource source;
    private float launchVelocity = 700f;
    private Transform tankTop;
    private const float _launchDelayMin = 1f;
    private const float _launchDelayMax = 5f;

    private void Start()
    {
        tankTop = gameObject.transform.GetChild(1);
    }
    
    public void startFiring()
    {
        Invoke(nameof(LaunchProjectile), 1f);
    }

    private void LaunchProjectile()
    {
        if (!Room3Tracker.firing)
        {
            return;
        }
        tankTop.GetComponent<Renderer>().material.color = Color.red;
        GameObject axe = Instantiate(projectile, transform.position,  
            transform.rotation);
        Vector3 direction = chicken.transform.position - transform.position;
        direction.Normalize();
        axe.GetComponent<Rigidbody>().AddForce(direction * launchVelocity);

        source.clip = currentClip;
        source.Play();

        StartCoroutine(LaunchDelay());
    }

    private IEnumerator LaunchDelay()
    {
        float launchDelay = Random.Range(_launchDelayMin, _launchDelayMax);
        yield return new WaitForSeconds(launchDelay);
        tankTop.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1f);
        Invoke(nameof(LaunchProjectile), launchDelay);
    }
}
