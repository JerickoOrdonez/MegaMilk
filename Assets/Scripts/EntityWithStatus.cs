using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityWithStatus : BoardEntity
{
    [SerializeField]Image healthBar;

    void Start()
    {
        moveInitiate(currentCol, currentRow);
        healthBar.fillMethod = Image.FillMethod.Horizontal;
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    public override void TakeDamage(int damageAmt)
    {
        base.TakeDamage(damageAmt);
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }
}
