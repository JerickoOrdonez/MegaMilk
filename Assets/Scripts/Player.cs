using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BoardEntity
{
    [SerializeField] GameObject[] attacks;

    private void Start()
    {
        Debug.Log("tile2DArray: "+ PlayerBoard.current.tile2DArray.GetLength(0));
        Debug.Log("tile2DArray: " + PlayerBoard.current.tile2DArray.GetLength(1));
    }

    void Update()
    {
        playerInputHandler();
    }

    void playerInputHandler()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentRow < 4)
        {
            moveInitiate(currentCol, currentRow + 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentRow > 0)
        {
            moveInitiate(currentCol, (int)currentRow - 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentCol > 0)
        {
            moveInitiate(currentCol - 1, currentRow);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentCol < 3)
        {
            moveInitiate(currentCol + 1, currentRow);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentRow < 4)
        {
            initiateAttack(0, currentCol, currentRow + 1);
        }
    }

    void initiateAttack(int i, int startCol, int startRow)
    {
        Attack attackComponent = attacks[i].GetComponent<Attack>();

        Instantiate(attacks[i]);
        attackComponent.startAttackMovement(startCol, startRow);
    }
}
