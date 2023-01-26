using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    public GameObject ball1, ball2, ball3, ball4, ball5, ball6;      /// 1 = Purp, 2 = Blue, 3 = Red, 4 = Yell, 5 = Pink, 6 = Grey
    public GameObject mainPanel, rowPanel, shooterPanel;


    private List<GameObject> rowPanelList = new List<GameObject>();
    private List<RowBalls> rowBalls = new List<RowBalls>(); 
    private List<int> Ylist = new List<int>();
    Random random = new Random();
    private int Y = -60, X, tempX, tempY;
    private int panelCount;
    private int firstPanelCount;
    private int ballCount;
    private int mainPanelWidth;
    private int mainPanelHeight;

    void Start()
    {
        try
        {
            rowPanel.transform.localPosition = new Vector3(0, Y, 0);
            RectTransform mainPanelTransform = mainPanel.GetComponent<RectTransform>();
            mainPanelWidth = (int)mainPanelTransform.rect.width;
            mainPanelHeight = (int)mainPanelTransform.rect.height;
            ballCount = mainPanelWidth / 120;
            panelCount = mainPanelHeight / 120;
            firstPanelCount = (panelCount / 2);
            
            CreateRows();
            MainRows();
            
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Sol fare tiklandi");
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            Debug.Log("Fare roulette çevrildi");
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (mouseX != 0f || mouseY != 0f)
        {
            Debug.Log("Fare hareket etti, X: " + mouseX + " Y: " + mouseY);
        }
    }

    void CreateRows()
    {
        for (int i = 0; i < panelCount; i++)
        {
            GameObject rowPanelInstance = Instantiate(rowPanel);            /// rowPanel prefabi kopyalaniyor.
            RectTransform rowPanelRectTransform = rowPanelInstance.GetComponent<RectTransform>();
            rowPanelInstance.name = "RowPanel" + i.ToString();
            rowPanelInstance.transform.SetParent(mainPanel.transform);      /// Her satırin konumlandirilmasi yapiliyor.
            rowPanelInstance.transform.localPosition = new Vector3(0, Y, 0);
            rowPanelInstance.transform.localScale = new Vector3(1, 1, 1);
            rowPanelRectTransform.offsetMin = new Vector2(0, rowPanelRectTransform.offsetMin.y);
            rowPanelRectTransform.offsetMax = new Vector2(0, rowPanelRectTransform.offsetMax.y);
            rowPanelList.Add(rowPanelInstance);                             /// Her satir rowPanelList'esine ekleniyor.
            Ylist.Add(Y);
            Y -= 120;
        }
    }

    void MainRows()
    {
        try
        {
            for (int i = 0; i < firstPanelCount; i++)
            {
                List<int> rowBallsIndexes = new List<int>();                    /// Satirdaki toplarin indekslerini tutan liste.
                AddBallsFull(rowPanelList[i], rowBallsIndexes, i);
                rowBalls.Add(new RowBalls(rowPanelList[i], rowBallsIndexes));
                rowBalls[i].X = tempX;
                rowBalls[i].Y = Ylist[i];
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

    void AddBallsFull(GameObject row, List<int> rowBallsIndexes, int index)
    {
        try
        {
            int tempBallCount = ballCount;

            GameObject ballInstance = null;
            if(index % 2 == 0)
            {
                ballCount = (mainPanelWidth / 120);
                X = -(mainPanelWidth / 2 - 60);     // -480
                tempX = X;
            }
            else
            {
                ballCount = (mainPanelWidth / 120) -1;
                X = -(mainPanelWidth / 2 - 120) ;     // -420
                tempX = X;
            }
            for (int i = 0; i < ballCount; i++)
            {
                AddBalls(row, ballInstance, random.Next(0, 6), rowBallsIndexes);
                X += 120;
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
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

    
    /*void DownRow(GameObject rowPanel)
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
    }*/
}
