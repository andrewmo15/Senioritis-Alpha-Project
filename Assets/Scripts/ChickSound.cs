using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickSound : MonoBehaviour
{
    public AudioClip currentClip;
    public AudioSource source;

    public float waitTimeCountdown = -1f;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                source.clip = currentClip;
                source.Play();
                waitTimeCountdown = Random.Range(5f, 20f);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}
