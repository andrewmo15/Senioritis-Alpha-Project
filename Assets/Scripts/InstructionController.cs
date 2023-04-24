using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InstructionController : MonoBehaviour
{
    public GameObject instructionsPanel;
    public float displayTime = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideInstructionsAfterDelay());
    }

    IEnumerator HideInstructionsAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        instructionsPanel.SetActive(false);
    }
}
