using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoTopDown : MonoBehaviour
{
    float movX,movY;
    Rigidbody2D rbtopdown;
    public float speed;
    Animator playeranim;
    // Start is called before the first frame update
    void Start()
    {
        rbtopdown=GetComponent<Rigidbody2D>();
        playeranim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movX=Input.GetAxisRaw("Horizontal")*speed;
        movY=Input.GetAxisRaw("Vertical")*speed;

        playeranim.SetFloat("movX",Input.GetAxisRaw("Horizontal"));
        playeranim.SetFloat("movY",Input.GetAxisRaw("Vertical"));
    }

// Esto es una alternativa (mejor) a estar multiplicando todo por Time.deltaTime
    void FixedUpdate(){
        rbtopdown.velocity=new Vector2(movX,movY);
    }
}
