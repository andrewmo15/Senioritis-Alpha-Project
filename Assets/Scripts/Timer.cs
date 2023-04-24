using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float time;
    public TextMeshProUGUI timer;
    private bool timerOn;
    // Start is called before the first frame update
    void Start()
    {
        timerOn = false;
        time = 1200;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn) {
            if (time > 0) {
                time -= Time.deltaTime;
                updateTimer(time);
            } else {
                SceneManager.LoadScene("GameOver");
                Time.timeScale = 1f;
            }
        }
    }

    public void setTimerOn() {
        timerOn = true;
    }

    void updateTimer(float currentTime) {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timer.SetText("Time remaining: " + string.Format("{0:00} : {1:00}", minutes, seconds));
    }
}
