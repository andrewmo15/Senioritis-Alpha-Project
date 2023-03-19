using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject actualDoor;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        animator = actualDoor.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            animator.SetBool("open", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            animator.SetBool("open", false);
        }
    }
}
