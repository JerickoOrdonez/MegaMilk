using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityWithStatus
{
    [SerializeField] GameObject[] attacks;

    void Update()
    {
        playerInputHandler();
    }

    void playerInputHandler()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentRow < PlayerBoard.current.getRowLimit() - 1)
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
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentCol < PlayerBoard.current.getColLimit() - 1)
        {
            moveInitiate(currentCol + 1, currentRow);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentRow < PlayerBoard.current.getRowLimit() - 1)
        {
            initiateAttack(0, currentCol, currentRow + 1);
        }
    }

    void initiateAttack(int attackIndex, int startCol, int startRow)
    {
        GameObject attack = Instantiate(attacks[attackIndex]);
        Attack attackComponent = attack.GetComponent<Attack>();

        attackComponent.startAttackMovement(startCol, startRow);
    }
}
