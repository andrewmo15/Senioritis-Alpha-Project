using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            SceneManager.LoadScene("WinnScene");
            Time.timeScale = 1f;
        }
    }
}
