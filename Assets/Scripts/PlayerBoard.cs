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

    void initializeBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                current.tile2DArray[i, j] = new MoveTile(i,j);
                Debug.Log("t2DArrayMT: " + tile2DArray[i, j]);

                GameObject clone = Instantiate(tilePrefab);
                clone.transform.position = new Vector3(i,0,j);
            }
        }
    }
}
