using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadCollider : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            var canvas = panel.gameObject.GetComponent<CanvasGroup>();
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        }
    }
}
