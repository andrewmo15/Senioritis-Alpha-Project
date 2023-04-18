using UnityEngine;
using UnityEngine.UI;

public class ButcherWarningToggler : MonoBehaviour
{
    public GameObject butcher;
    public GameObject chicken;
    public float maxDistance;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    void Update()
    {
        float distance = (butcher.transform.position - chicken.transform.position).magnitude;
        if (distance <= maxDistance)
        {
            // Enable the red overlay when butcher is near
            image.enabled = true;
            Color tempColor = image.color;
            // Interpolate between 0.1 and 0.3 alpha transparency depending on distance
            tempColor.a = Mathf.Lerp(0.1f, 0.3f, 1.0f - (distance / maxDistance));
            image.color = tempColor;
        }
        else
        {
            // Disable the red overlay when butcher is far
            image.enabled = false;
        }
    }
}