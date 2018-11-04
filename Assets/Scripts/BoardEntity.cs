using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEntity : MonoBehaviour
{
    [SerializeField]protected int currentCol = 0;
    [SerializeField] protected int currentRow = 0;

    [SerializeField]protected int health;
    [SerializeField]protected int maxHealth = 100;

    void Start()
    {
        moveInitiate(currentCol, currentRow);
    }

	public void moveInitiate(int col, int row){
        MoveTile tileToMoveTo = PlayerBoard.current.tile2DArray[col, row];
        MoveTile tileMovedFrom = PlayerBoard.current.tile2DArray[currentCol, currentRow];

        moveBehavior(tileToMoveTo, tileMovedFrom, col , row);	
    }

    /// <summary>
    /// This function determines how a BoardEntity should move. By default, it simply calls moveAction and passes
    /// its params along. This is separated from moveAction so that each can be overridden individually.
    /// </summary>
    public virtual void moveBehavior(MoveTile tileToMoveTo, MoveTile tileMovedFrom, int col, int row)
    {
        moveAction(tileToMoveTo, tileMovedFrom, col, row);
    }

    /// <summary>
    /// This function determines what happens in the event of a movement collision , and then calls
    /// moveOBjectToTile to handle the movement. A movement collision is when the BoardEntity that 
    /// calls this tries to move into an occupied space.
    /// </summary>
    public virtual void moveAction(MoveTile tileToMoveTo, MoveTile tileMovedFrom, int col, int row)
    {
        if (tileToMoveTo.occupant != null) return;
        moveObjectToTile(tileToMoveTo, tileMovedFrom, col, row);
    }

    public void moveObjectToTile(MoveTile tileToMoveTo, MoveTile tileMovedFrom, int col, int row)
    {
        transform.position = new Vector3(col, 0, row);
        currentCol = col;
        currentRow = row;

        tileMovedFrom.setOccupant(null);
        tileToMoveTo.setOccupant(gameObject);
    }

    public virtual void TakeDamage(int damageAmt)
    {
        health -= damageAmt;
        if(health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        PlayerBoard.current.tile2DArray[currentCol, currentRow].occupant = null;
        Destroy(gameObject,.5f);
    }
}
