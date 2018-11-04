using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile
{
    public Vector2 position;
    public GameObject occupant = null;

    public MoveTile(int i , int j)
    {
        position = new Vector2(i,j);
    }

    public void setOccupant(GameObject newOccupant)
    {
        occupant = newOccupant;
        //Debug.Log($"Occupant for MT({position.x},{position.y}) is {occupant}");
    }
}
