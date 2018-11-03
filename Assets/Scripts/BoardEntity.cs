using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEntity : MonoBehaviour
{
    [SerializeField]protected int currentCol = 0;
    [SerializeField] protected int currentRow = 0;

    [SerializeField]int health;
    [SerializeField]int maxHealth = 100;

    void Start()
    {
        moveInitiate(currentCol, currentRow);
    }

	public void moveInitiate(int i, int j){
        MoveTile tileToMoveTo = PlayerBoard.current.tile2DArray[i, j];
        MoveTile tileMovedFrom = PlayerBoard.current.tile2DArray[currentCol, currentRow];

        moveAction(tileToMoveTo, tileMovedFrom, i , j);	
    }

    //Consider using this as an inheritable function to define custom behaviors
    public void moveAction(MoveTile tileToMoveTo, MoveTile tileMovedFrom, int i, int j)
    {
        moveObjectToTile(tileToMoveTo, tileMovedFrom, i, j);
    }

    public void moveObjectToTile(MoveTile tileToMoveTo, MoveTile tileMovedFrom, int i, int j)
    {
        if (tileToMoveTo.occupant != null) return;
        transform.position = new Vector3(i, 0, j);
        currentCol = i;
        currentRow = j;

        tileMovedFrom.setOccupant(null);
        tileToMoveTo.setOccupant(gameObject);
    }
}
