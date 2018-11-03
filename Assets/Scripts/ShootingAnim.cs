using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAnim : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("param_isShooting", true);
        }


        anim.SetBool("param_isShooting", false);
    }
}
