using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    
    
    private Rigidbody2D frogBody;
    
    private bool moveLeft;
    private bool moveRight; 
    public Sprite knightBodyFront;
    public Sprite knightBodyBack;
    //private int facing;
    //public float movespeed = 0.01f;
    

       

    void Start() {
        
        frogBody = GetComponent<Rigidbody2D>();         
        //facing = 1;
        
        
    }

    public void AddForceRight() {

        /*frogBody.velocity = new Vector2 (0, 0);
        frogBody.AddForce(new Vector2(80, 30), ForceMode2D.Impulse);
        //frogBody.velocity = new Vector2(movespeed, frogBody.velocity.y);*/
        
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = knightBodyBack;
        
        Vector2 moveRight = new Vector2(transform.position.x, Input.GetAxis("Vertical"));
        frogBody.MovePosition(frogBody.position + moveRight);
    }
    public void AddForceLeft() {

        /*frogBody.velocity = new Vector2 (0, 0);
        frogBody.AddForce(new Vector2(-80, 30), ForceMode2D.Impulse);
        //frogBody.velocity = new Vector2(-movespeed, frogBody.velocity.y);*/
        
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = knightBodyFront;

        Vector2 moveLeft = new Vector2(-transform.position.x, Input.GetAxis("Vertical"));
        frogBody.MovePosition(frogBody.position + moveLeft);
        
    }
    

    /*void Update() {

        

        
        if (moveRight) {

            AddForceRight ();
            /*if (facing == 1) {
                transform.parent.localScale = new Vector3(1f, 1f, 1f);
                facing = 0;
            }*/
        //}
        
        /*if (moveLeft) {

            AddForceLeft ();  
            /*if (facing == 0) {
                transform.parent.localScale = new Vector3(-1f, 1f, 1f);
                facing = 1;
            }*/    
                       
            
        
        //}
        
        
    }

    
    
    
//}
