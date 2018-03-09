using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{


    private GameObject parent;
    private GameObject empty;
    private GameObject counter;
    private GameObject gameScript;
    private AudioSource click;

    // Use this for initialization
    void Start () {
        parent = GameObject.Find("cells");
        empty = GameObject.Find("0");
        counter = GameObject.Find("CountText");
        gameScript = GameObject.Find("Main Camera");
        click = GetComponent<AudioSource>();
	}
	
    private void OnMouseDown()
    {
        if (name != "0" && gameScript.GetComponent<GameScript>().GameStarted == true)
        {
            CheckChip();
        }
    }

    public void CheckChip()
    {
        Vector2 thisPosition = transform.position - parent.transform.position;
        Vector2 emptyPosition = empty.transform.position - parent.transform.position;
        float emptyCellX = Mathf.Abs(thisPosition.x - emptyPosition.x);
        float emptyCellY = Mathf.Abs(thisPosition.y - emptyPosition.y);
        if (emptyCellX + emptyCellY == 10)
        {
            Swap();
            counter.GetComponent<Count>().Counter();
            parent.GetComponent<Area>().CheckWin();
        }     
    }

    public void Swap()
    {
        Vector2 temp = empty.transform.position;
        empty.transform.position = transform.position;
        transform.position = temp;
        click.Play();
    }
    /// <summary>
    /// метод CheckChip() находит разницу в позиции между фишкой на которую кликает игрок и пустой ячейкой, если она равна 10, то вызывает метод, который меняет их местами
    /// 
    /// </summary>
}
