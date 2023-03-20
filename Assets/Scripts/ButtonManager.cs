using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Drag & Drop the objects with the `ClickTarget` component
    [SerializeField]
    private TriggerButton[] targets;

    // Each target will have an index (based on its position in the previous array)
    // This variable will indicate which target must be clicked
    private int expectedTargetIndex;

    // floor tile boolean
    public FloorColorChange tile;

    // Called when the scene starts
    private void Start()
    {
        expectedTargetIndex = 0;

        // For each target, call a function when they are clicked
        for (int i = 0; i < targets.Length; i++)
        {
            // You have to declare a temporary index to prevent the "closure problem"
            int closureIndex = i;

            targets[closureIndex].OnTargetCollisionEvent += (target) => OnTargetCollide(target, closureIndex);

        }
    }

    // Function called when a target is clicked
    private void OnTargetCollide(TriggerButton target, int index)
    {
        Debug.Log(target.name + " has been pushed!");

        print(target.name + " pushed");

        if (index == expectedTargetIndex)
        {
            Debug.Log("The correct target has been pushed");
 
            expectedTargetIndex++;
            if (expectedTargetIndex == targets.Length)
            {
                Debug.Log("The last target has been pushed : Loading next scene");
                GameObject g = GameObject.FindGameObjectWithTag("ColorFloor");
                tile = g.GetComponent<FloorColorChange>();

                tile.colorChange = false;
     

            }
        }
        else
        {
            Debug.Log("The wrong target has been pushed");
            expectedTargetIndex = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
}

