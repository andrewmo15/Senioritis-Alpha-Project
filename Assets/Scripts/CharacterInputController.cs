using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    private float filteredForwardInput;
    private float filteredTurnInput;
    private float forwardSpeedLimit = 1f;

    public float forwardInputFilter = 5f;
    public float turnInputFilter = 5f;

    public float Forward { get; private set; }

    public float Turn { get; private set; }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // circular coordinates
        h *= Mathf.Sqrt(1f - 0.5f * v * v);
        v *= Mathf.Sqrt(1f - 0.5f * h * h);

        filteredForwardInput = Mathf.Clamp(Mathf.Lerp(filteredForwardInput, v,
            Time.deltaTime * forwardInputFilter), 0, forwardSpeedLimit);

        filteredTurnInput = Mathf.Lerp(filteredTurnInput, h,
            Time.deltaTime * turnInputFilter);

        Forward = filteredForwardInput;
        Turn = filteredTurnInput;
    }
}