using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEntity : MonoBehaviour
{
    [SerializeField]protected Vector2 currentPosition;

    [SerializeField]int health;
    [SerializeField]int maxHealth = 100;

    void Start()
    {
        moveInitiate((int)currentPosition.x,(int)currentPosition.y);
    }

	public void moveInitiate(int i, int j){
        MoveTile tileToMoveTo = PlayerBoard.current.tile2DArray[i, j];
        MoveTile tileMovedFrom = PlayerBoard.current.tile2DArray[(int)currentPosition.x, (int)currentPosition.y];

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
        currentPosition = new Vector2(i, j);

        tileMovedFrom.setOccupant(null);
        tileToMoveTo.setOccupant(gameObject);
    }
}
