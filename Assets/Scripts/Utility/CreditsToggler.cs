using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsToggler : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject menuPanel;

    public void toggleCredits()
    {
        if (creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
        else
        {
            creditsPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
    }
}
