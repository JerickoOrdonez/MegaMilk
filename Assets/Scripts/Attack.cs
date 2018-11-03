using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Player
{
    public int moveTime;

    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        
            Instantiate(gameObject);
            for (int i = 0; i < 5; i++)
            {
                moveInitiate(currentCol, currentRow + 1);
                yield return new WaitForSeconds(1);
                if (i >= 4) Destroy(gameObject);
            }
    }
}
