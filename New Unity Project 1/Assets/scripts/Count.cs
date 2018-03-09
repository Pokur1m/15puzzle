using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{

    private Text countText;
    private int countValue = 0;

    public int CountValue
    {
        get
        {
            return countValue;
        }

        set
        {
            countValue = value;
        }
    }

    void Start () {
        countText = GetComponent<Text>();
        countText.text = "Количество ходов: " + CountValue.ToString();
    }
	
    public void Counter()
    {
        CountValue++;
        countText.text = "Количество ходов: " + CountValue.ToString();
    }

    public void NewCounter()
    {
        CountValue = 0;
        countText.text = "Количество ходов: " + CountValue.ToString();
    }

    /// <summary>
    /// метод Counter() считает количество ходов и выводит его в текстовое поле
    /// метод NewCounter() обнуляет счетчик ходов
    /// </summary>
}
