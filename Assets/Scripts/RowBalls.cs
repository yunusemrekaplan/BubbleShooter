using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class RowBalls : MonoBehaviour
{
    public GameObject rowPanel; 
    public List<int> indexes = new List<int>();
    public int X { get; set; }
    public int Y { get; set; }

    public RowBalls(GameObject rowPanel, List<int> indexes)
    {
        this.rowPanel = rowPanel;
        this.indexes = indexes;
    }
}

