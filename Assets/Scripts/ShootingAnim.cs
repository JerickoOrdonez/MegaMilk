using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAnim : MonoBehaviour
{
    public Animator anim;

    private KeyCode Space;

    void Update()
    {
        if (Input.GetKeyDown(Space))
            anim.Play("shoot");
    }
}
