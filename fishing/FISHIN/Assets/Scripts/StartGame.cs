using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TMP_Text TimerText;
    public TMP_Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        ScoreText.text = "HIGHSCORE: " + FishingHook.Highscore;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn == true)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                TimerText.text = "TURN THE HANDLE TO BEGIN";
            }
        }
        
        if (Input.anyKeyDown && TimeLeft <= 0)
        {
            SceneManager.LoadScene("FishingGame");
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
