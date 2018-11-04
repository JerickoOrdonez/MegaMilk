using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BoardEntity
{
    [SerializeField]float moveTime = .1f;
    [SerializeField]int damage = 50;

    private bool isAlive = true;

    public void startAttackMovement(int spawnCol, int spawnRow)
    {
        moveInitiate(spawnCol, spawnRow);
        StartCoroutine(MovementCoroutine());
    }

    public override void moveAction(MoveTile tileToMoveTo, MoveTile tileMovedFrom, int col, int row)
    {
        if (tileToMoveTo.occupant == null)
        {
            moveObjectToTile(tileToMoveTo, tileMovedFrom, col, row);
        }
        else if (tileToMoveTo.occupant.tag == "Enemy")
        {
            tileToMoveTo.occupant.GetComponent<BoardEntity>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //else if(tileToMoveTo.occupant)
        //{
        //    Destroy(gameObject);
        //}
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
