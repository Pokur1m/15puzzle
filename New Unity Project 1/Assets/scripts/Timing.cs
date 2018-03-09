using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timing : MonoBehaviour
{
    private float seconds = 0.0f;
    private int minutes = 0;
    private Text timerText;

    public Text TimerText
    {
        get
        {
            return timerText;
        }

        set
        {
            timerText = value;
        }
    }

    void Start () {
        TimerText = GetComponent<Text>();

    }

    public void GetTime()
    {
        seconds += Time.deltaTime;
        if(seconds > 59)
        {
            seconds = 0.0f;
            minutes++;
        }
        TimerText.text = "Время: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public void NewTime()
    {
        minutes = 0;
        seconds = 0.0f;
        TimerText.text = "Время: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    /// <summary>
    /// метод GetTime() выводит время игры в текстовое поле
    /// метод NewTime() обнуляет таймер, вызывается при начале игры
    /// </summary>
}