using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButcherFootstepEmitter : MonoBehaviour
{
    public GameObject butcher;
    public GameObject chicken;
    public float audibleDistance;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = (butcher.transform.position - chicken.transform.position).magnitude;
        if (distance < audibleDistance)
        {
            audioSource.Play();
        } else
        {
            audioSource.Stop();
        }
    }
}
