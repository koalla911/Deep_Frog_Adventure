using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    

    private bool moveLeft;
    private bool moveRight; 
    //public float movespeed = 50f;
    //[SerializeField] private Transform target;
    
    public void MoveRight() {
        if (_directionState == DirectionState.Left) {
            _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            _directionState = DirectionState.Right;
        }
    }

    public void MoveLeft() {
        if (_directionState == DirectionState.Right) {
            _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            _directionState = DirectionState.Left;
        }
    }
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;

    }
    
   

    /*public void Flip() {

        

        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);


        
    }*/

    void Update() {

        if (moveLeft) 
        {

            MoveLeft();

        
                       
            //transform.Rotate(Time.deltaTime * 0f, 0f, 20f);
        }
        if (moveRight) 
        {
            MoveRight();
        }

        
        
    }  

    enum DirectionState {
        Right,
        Left
    }
}
