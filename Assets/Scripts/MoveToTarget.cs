using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        transform.position = target.transform.position;
    }
}
