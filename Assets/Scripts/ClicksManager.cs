using UnityEngine;
using UnityEngine.SceneManagement;

public class ClicksManager : MonoBehaviour
{
    // Drag & Drop the objects with the `ClickTarget` component
    [SerializeField]
    private ClickTarget[] targets;

    // Each target will have an index (based on its position in the previous array)
    // This variable will indicate which target must be clicked
    private int expectedTargetIndex;

    // Called when the scene starts
    private void Start()
    {
        expectedTargetIndex = 0;

        // For each target, call a function when they are clicked
        for (int i = 0; i < targets.Length; i++)
        {
            // You have to declare a temporary index to prevent the "closure problem"
            int closureIndex = i;

            targets[closureIndex].OnTargetClickedEvent += (target) => OnTargetClicked(target, closureIndex);
           
        }
    }

    // Function called when a target is clicked
    private void OnTargetClicked(ClickTarget target, int index)
    {
        Debug.Log(target.name + " has been clicked!");

        print(target.name + " clicked");

        if (index == expectedTargetIndex)
        {
            Debug.Log("The correct target has been clicked");
            print("clicked");
            expectedTargetIndex++;
            if (expectedTargetIndex == targets.Length)
            {
                Debug.Log("The last target has been clicked : Loading next scene");
                print("clicked");


            }
        }
        else
        {
            Debug.Log("The wrong target has been clicked");
            expectedTargetIndex = 0;
        }
    }
}

