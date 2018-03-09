using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Vector2[] positionCell = new Vector2[16];
    [SerializeField]
    private GameObject[] cells = new GameObject[16];
    private int[] tempArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
    private int[] startArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
    private int[] currentArray = new int[16];
    private AudioSource winSound;

    public GameObject[] GetCells()
    {
        return (GameObject[])cells.Clone();
    }

    void Start()
    {
        winSound = GetComponent<AudioSource>();
        for(int i=0; i<cells.Length; i++)
        {
            cells[i] = GameObject.Find(i.ToString());
        }
    }

    public void CreateArea()
    {
        positionCell[0] = new Vector2(15, 40);
        positionCell[1] = new Vector2(25, 40);
        positionCell[2] = new Vector2(35, 40);
        positionCell[3] = new Vector2(45, 40);
        positionCell[4] = new Vector2(15, 30);
        positionCell[5] = new Vector2(25, 30);
        positionCell[6] = new Vector2(35, 30);
        positionCell[7] = new Vector2(45, 30);
        positionCell[8] = new Vector2(15, 20);
        positionCell[9] = new Vector2(25, 20);
        positionCell[10] = new Vector2(35, 20);
        positionCell[11] = new Vector2(45, 20);
        positionCell[12] = new Vector2(15, 10);
        positionCell[13] = new Vector2(25, 10);
        positionCell[14] = new Vector2(35, 10);
        positionCell[15] = new Vector2(45, 10);
        CheckParity();
    }

    public void RandomArray()
    {
        for (int i = 15; i >= 0; i--)
        {
            int j = Random.RandomRange(0, i);
            int temp = tempArray[i];
            tempArray[i] = tempArray[j];
            tempArray[j] = temp;
        }

    }

    public void RandomCells()
    {
        int temp;
        for (int i = 0; i < cells.Length; i++)
        {
            temp = tempArray[i];
            cells[i].transform.position = positionCell[temp];
        }
        
        for (int i = 0; i < cells.Length; i++)
        {
            for (int j = 0; j < cells.Length; j++)
            {
                if (cells[j].transform.position.x == positionCell[i].x && cells[j].transform.position.y == positionCell[i].y)
                {
                    currentArray[i] = j;
                }            
            }
        }
    }

    public void CheckParity()
    {
        bool check = false;
        int sumParity = 0;
        int tempSum = 0;
        int emptyIndex = 0;
        while (check == false)
        {
            sumParity = 0;
            RandomArray();
            RandomCells();
            for (int i = 0; i < currentArray.Length; i++)
            {
                tempSum = 0;
                for (int j = i + 1; j < currentArray.Length; j++)
                {
                    if (currentArray[i] > currentArray[j] && currentArray[j] != 0)
                    {
                        tempSum++;
                    }
                }
                sumParity += tempSum;
            }
            
            emptyIndex = tempArray[0] + 1;


            if (emptyIndex % 4 == 0)
            {
                emptyIndex = emptyIndex++ / 4;
            }
            else
            {
                emptyIndex = emptyIndex / 4 + 1;
            }
            sumParity += emptyIndex;
            if (sumParity % 2 == 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }

    }

    public void CheckWin()
    {
        int count = 0;
        for (int i = 0; i < cells.Length; i++)
        {
            for (int j = 0; j < cells.Length; j++)
            {
                if (cells[j].transform.position.x == positionCell[i].x && cells[j].transform.position.y == positionCell[i].y)
                {
                    currentArray[i] = j;
                }
            }
        }
        for (int i = 0; i < cells.Length; i++)
        {
            if (currentArray[i] == startArray[i])
            {
                count++;
            }
        }
        if (count == 16)
        {
            Win();
        }
    }

    public void Win()
    {
        GameObject.Find("Main Camera").GetComponent<GameScript>().GameStarted = false;
        winSound.Play();
    }

    /// <summary>
    /// этот скрипт отвечает за расстановку фишек на игровом поле.
    /// 
    /// массив positionCell будет хранить начаьлные позиции фишек в формате Vector2
    /// массив cells будет хранить сами фишки в формате GameObject
    /// массив tempArray нужен для того, чтобы расставить фишки в случайном порядке
    /// массив startArray хранит начальный порядок фишек, чтобы определить победу
    /// массив currentArray хранит текущий порядок фишек, чтобы определить победу
    /// 
    /// в методе CreateArea() заполняется массив из начальных положений фишек и вызывается метод проверки случайной расстановки фишек на возможность сборки
    /// 
    /// метод RandomArray() сортирует массив в случайном порядке
    /// 
    /// метод RandomCells() присваивает случайные позиции фишкам, и заполняет массив tempArray номерами фишек в получившемся порядке
    /// 
    /// метод CheckParity() вызывает методы которые сортируют массив в случайном порядке и расставляет фишки в случайном порядке до тех пор пока не выполнится условие, которое проверяет возможность
    /// сбора пятнашек из случайной комбинации фишек.
    /// 
    /// метод CheckWin() сравнивает массив с текущим порядком фишек со стартовым, если они одинаковы, то вызывается метод победы
    /// </summary>

}
