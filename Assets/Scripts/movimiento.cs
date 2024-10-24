using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    Animator animPlayer;
    Rigidbody2D rbPlayer;
    void Start()
    {
        animPlayer=GetComponent<Animator>();
        rbPlayer=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetAxis("Horizontal")>0)
        {
            animPlayer.SetBool("RUN",true);
            rbPlayer.velocity=Vector2.right*10;
        }
        else if(Input.GetAxis("Horizontal")<0)
        {
            animPlayer.SetBool("RUN",true);
            rbPlayer.velocity=Vector2.left*10;
        }
        else{
            animPlayer.SetBool("RUN",false);
            rbPlayer.velocity=Vector2.zero;
        }
    }
}
