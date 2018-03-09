using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    private bool gameStarted = false;
    private float ratio;
    public bool GameStarted
    {
        get
        {
            return gameStarted;
        }

        set
        {
            gameStarted = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        ratio = (float) Screen.height / Screen.width;
        Camera.main.orthographicSize = 1400 * ratio / 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStarted == true)
        {
            GameObject.Find("TimerText").GetComponent<Timing>().GetTime();
        }
    }

    public void GameStart()
    {
        GameStarted = true;
        GameObject.Find("TimerText").GetComponent<Timing>().NewTime();
        GameObject.Find("cells").GetComponent<Area>().CreateArea();
        GameObject.Find("CountText").GetComponent<Count>().NewCounter();
    }

    public void GameStop()
    {
        GameStarted = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
    /// <summary>
    /// метод GameStart() Вызывает методы обнуления таймера и счетчика ходов, а так же метод который отвечает за расстановку фишек
    /// </summary>
}
