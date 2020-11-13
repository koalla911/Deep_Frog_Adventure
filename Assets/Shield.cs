using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool moveLeft;
    private bool moveRight; 
    public Sprite sword;
    public Sprite shield;
    //public Rigidbody2D equipment;

    void Start() {
        
        //equipment = this.GetComponent<Rigidbody2D>();         
        
        
        
    }

    public void TurnRight () {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shield;

    }
    public void TurnLeft () {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sword;
    }
    void Update() {

        

        
        if (moveRight) {

            TurnRight ();
                        
        
        }
        if (moveLeft) {

            TurnLeft ();        
                       
            
        
        }
        
        
    }
}
