using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoSideScroll : MonoBehaviour
{
    float movX,movY;
    Rigidbody2D rbtopdown;
    public float speed;
    Animator playeranim;
    public float jumpForce;
    public int jumps;
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

        playeranim.SetFloat("movX",Input.GetAxisRaw("Horizontal"));

        if(Input.GetButtonDown("Jump")&&jumps>0){
            rbtopdown.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            jumps--;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Suelo")){
            jumps=2;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Muerte")){
            transform.position=Vector2.zero;
        }
    }

// Esto es una alternativa (mejor) a estar multiplicando todo por Time.deltaTime
    void FixedUpdate(){
        rbtopdown.velocity=new Vector2(movX,rbtopdown.velocity.y);
    }
}
