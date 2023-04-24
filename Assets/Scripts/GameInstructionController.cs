using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInstructionController : MonoBehaviour
{
    public GameObject plotPanel;
    public GameObject instructionPanel;
    public Button continueButton;
    public float plotDisplayDuration = 5.0f; // Duration to display the plot in seconds
    public Timer timerController;

    void Start()
    {
        // Set the button onClick listener
        continueButton.onClick.AddListener(StartGame);

        // Display the plot and instructions
        StartCoroutine(DisplayPlotAndInstructions());
    }

    IEnumerator DisplayPlotAndInstructions()
    {
        // Pause the game
        Time.timeScale = 0;

        // Display the plot
        plotPanel.SetActive(true);
        instructionPanel.SetActive(false);

        // Wait for the specified duration
        yield return new WaitForSecondsRealtime(plotDisplayDuration);

        // Hide the plot and display the instructions
        plotPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void StartGame()
    {
        // Unpause the game
        Time.timeScale = 1;

        // Hide the instruction panel
        instructionPanel.SetActive(false);
        timerController.setTimerOn();
    }
}
