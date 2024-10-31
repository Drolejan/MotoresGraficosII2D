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
    public checkpoints checkpoint;
    public int savedCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        rbtopdown=GetComponent<Rigidbody2D>();
        playeranim=GetComponent<Animator>();
        //Comenzamos en el primer checkpoint
        transform.position=checkpoint.checkpoint.position;
        //Esto es lo mismo pero para el sistema de guardado
        transform.position=checkpoint.transforms[savedCheckpoint].position;
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
            //Mueres y regresas al checkpoint (sin salvado)
            transform.position=checkpoint.checkpoint.position;
            //Con sistema de salvado
            transform.position=checkpoint.transforms[savedCheckpoint].position;
        }

        if(col.gameObject.CompareTag("Checkpoint")){
            //Asignamos este objeto como el nuevo checkpoint
            checkpoint.checkpoint=col.gameObject.transform;
            col.enabled=false;//desactivamos la colision del checkpoint
            //Actualizamos la lista de checkpoints
            savedCheckpoint++;
        }
    }

// Esto es una alternativa (mejor) a estar multiplicando todo por Time.deltaTime
    void FixedUpdate(){
        rbtopdown.velocity=new Vector2(movX,rbtopdown.velocity.y);
    }
}
