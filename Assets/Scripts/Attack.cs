using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BoardEntity
{
    public float moveTime = .1f;
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
            yield return new WaitForSeconds(moveTime);
            moveInitiate(currentCol, currentRow + 1);
            if (currentRow >= PlayerBoard.current.getRowLimit() - 1) isAlive = false;
        }

        yield return new WaitForSeconds(moveTime);
        Destroy(gameObject);
    }
}
