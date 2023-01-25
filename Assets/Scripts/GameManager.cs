using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    public GameObject ball1, ball2, ball3, ball4, ball5, ball6;      /// 1 = Purp, 2 = Blue, 3 = Red, 4 = Yell, 5 = Pink, 6 = Grey
    public GameObject rowPanel, mainPanel;

    public List<GameObject> rowPanelList = new List<GameObject>();
    public List<RowBalls> rowBalls = new List<RowBalls>(); 

    Random random = new Random();
    public int Y = -60, X = -480;
    public int firstSize = 7;
    public int ballSize = 9;

    void Start()
    {
        try
        {
            rowPanel.transform.localPosition = new Vector3(0, Y, 0);
            ///InvokeRepeating("DownRow", 1.5f, 1.5f);
            MainRows();
            
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }


    void Update()
    {

    }

    /*void ReduceRowPanelPosition()
    {
        rowPanel1.transform.localPosition = new Vector3(rowPanel1.transform.localPosition.x, rowPanel1.transform.localPosition.y - 120, rowPanel1.transform.localPosition.z);
        
    }*/

    void MainRows()
    {
        try
        {
            for (int i = 0; i < firstSize; i++)
            {
                List<int> rowBallsIndexes = new List<int>();                    /// Satirdaki toplarin indekslerini tutan liste.
                GameObject rowPanelInstance = Instantiate(rowPanel);            /// rowPanel prefabi kopyalaniyor.
                rowPanelInstance.transform.SetParent(mainPanel.transform);      /// Her satırin konumlandirilmasi yapiliyor.
                rowBallsIndexes = AddBallsFull(rowPanelInstance);               /// Her satira toplar ekleniyor ve indeksleri geri donduruluyor.
                rowBalls.Add(new RowBalls(rowPanelInstance, rowBallsIndexes));  /// Her satirin satir bilgileri rowBalls listesine ekleniyor.
                DownRow(rowPanelInstance);
                rowPanelList.Add(rowPanelInstance);                             /// Her satir rowPanelList'esine ekleniyor.    
                X = -480;
            }
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
        
    }

    void AddBallsRandom()
    {

    }

    List<int> AddBallsFull(GameObject row)
    {
        List<int> rowBallsIndexes = new List<int>();
        try
        {
            GameObject ballInstance = null;
            for (int i = 0; i < ballSize; i++)
            {
                AddBalls(row, ballInstance, random.Next(0, 6), rowBallsIndexes);
                X += 120;
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
        return rowBallsIndexes;
    }

    void AddBalls(GameObject row, GameObject ballInstance, int randomNumber, List<int> rowBallsIndexes)
    {
        if (randomNumber == 0)
        {
            ballInstance = Instantiate(ball1);
            ballInstance.transform.SetParent(row.transform);
            ballInstance.transform.localScale = new Vector3(105, 105, 105);
            ballInstance.transform.localPosition = new Vector3(X, 0, -1);
            rowBallsIndexes.Add(randomNumber);
        }
        else if (randomNumber == 1)
        {
            ballInstance = Instantiate(ball2);
            ballInstance.transform.SetParent(row.transform);
            ballInstance.transform.localScale = new Vector3(105, 105, 105);
            ballInstance.transform.localPosition = new Vector3(X, 0, -1);
            rowBallsIndexes.Add(randomNumber);
        }
        else if (randomNumber == 2)
        {
            ballInstance = Instantiate(ball3);
            ballInstance.transform.SetParent(row.transform);
            ballInstance.transform.localScale = new Vector3(105, 105, 105);
            ballInstance.transform.localPosition = new Vector3(X, 0, -1);
            rowBallsIndexes.Add(randomNumber);
        }
        else if (randomNumber == 3)
        {
            ballInstance = Instantiate(ball4);
            ballInstance.transform.SetParent(row.transform);
            ballInstance.transform.localScale = new Vector3(105, 105, 105);
            ballInstance.transform.localPosition = new Vector3(X, 0, -1);
            rowBallsIndexes.Add(randomNumber);
        }
        else if (randomNumber == 4)
        {
            ballInstance = Instantiate(ball5);
            ballInstance.transform.SetParent(row.transform);
            ballInstance.transform.localScale = new Vector3(105, 105, 105);
            ballInstance.transform.localPosition = new Vector3(X, 0, -1);
            rowBallsIndexes.Add(randomNumber);
        }
        else
        {
            ballInstance = Instantiate(ball6);
            ballInstance.transform.SetParent(row.transform);
            ballInstance.transform.localScale = new Vector3(105, 105, 105);
            ballInstance.transform.localPosition = new Vector3(X, 0, -1);
            rowBallsIndexes.Add(randomNumber);
        }
    }

    void AddRow()
    {

    }

    void DownRow(GameObject rowPanel)
    {
        try
        {
            RectTransform rowPanelRectTransform = rowPanel.GetComponent<RectTransform>();
            rowPanel.transform.localPosition = new Vector3(0, Y, 0);
            rowPanel.transform.localScale = new Vector3(1, 1, 1);
            rowPanelRectTransform.offsetMin = new Vector2(0, rowPanelRectTransform.offsetMin.y);
            rowPanelRectTransform.offsetMax = new Vector2(0, rowPanelRectTransform.offsetMax.y);
            Y -= 120;
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
