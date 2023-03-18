using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AxeController : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x > 40 || pos.x < 5 || pos.z > 30 || pos.z < 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Chicken")) return;
        
        Room3Tracker.firing = false;
        Room3Tracker.resetTimeRemaining();
        SceneManager.LoadScene("GameOver");
    }
}
