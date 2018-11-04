using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile
{
    public Vector2 position;
    public GameObject occupant = null;

    public MoveTile(int col , int row)
    {
        position = new Vector2(col,row);
    }

    public void setOccupant(GameObject newOccupant)
    {
        occupant = newOccupant;
        //Debug.Log($"Occupant for MT({position.x},{position.y}) is {occupant}");
    }
}
