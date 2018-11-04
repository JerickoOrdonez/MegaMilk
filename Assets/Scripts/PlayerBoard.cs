using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : MonoBehaviour
{
    public static PlayerBoard current;

    public MoveTile[,] tile2DArray = new MoveTile[4,5];
    [SerializeField]GameObject tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        initializeBoard();
    }

    public int getColLimit()
    {
        return current.tile2DArray.GetLength(0);
    }

    public int getRowLimit()
    {
        return current.tile2DArray.GetLength(1);
    }

    void initializeBoard()
    {
        for (int col = 0; col < 4; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                current.tile2DArray[col, row] = new MoveTile(col,row);
                Debug.Log("t2DArrayMT: " + tile2DArray[col, row]);

                GameObject clone = Instantiate(tilePrefab);
                clone.transform.position = new Vector3(col,0,row);
            }
        }
    }
}
