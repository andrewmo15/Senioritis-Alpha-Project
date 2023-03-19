using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chicken")
        {
            Debug.Log("button triggered");
            animator.SetTrigger("button");
        }
    }

}