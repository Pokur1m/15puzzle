using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Timer {

	private Timer()
    {
    }

    private static Timer source = null;

    public static Timer GetTimer()
    {
        if(source == null)
        {
            source = new Timer();
        }
        return source;
    }

    private float timerValue = 0.0f;
    private string time = "0.0";
    public string Timing()
    {
        time = (timerValue += Time.deltaTime).ToString();
        return time;
    }
}
