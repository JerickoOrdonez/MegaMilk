using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BoardEntity
{
    public int Health;

    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentPosition.y < 4)
        {
            moveInitiate((int)currentPosition.x, (int)currentPosition.y + 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentPosition.y > 0)
        {
            moveInitiate((int)currentPosition.x, (int)currentPosition.y - 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPosition.x > 0)
        {
            moveInitiate((int)currentPosition.x - 1, (int)currentPosition.y);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentPosition.x < 3)
        {
            moveInitiate((int)currentPosition.x + 1, (int)currentPosition.y);
        }
    }
}
