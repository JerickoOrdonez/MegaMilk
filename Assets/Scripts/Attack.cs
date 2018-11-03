using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BoardEntity
{
    public float moveTime = 1;
    private bool isAlive = true;

    public void startAttackMovement(int spawnCol, int spawnRow)
    {
        moveInitiate(spawnCol, spawnRow);
        StartCoroutine(MovementCoroutine());
    }

    IEnumerator MovementCoroutine()
    {
        while (isAlive)
        {
            moveInitiate(currentCol, currentRow + 1);
            yield return new WaitForSeconds(moveTime);
            if (currentRow > PlayerBoard.current.getRowLimit() - 1) isAlive = false;
        }
        Destroy(gameObject);
    }
}
