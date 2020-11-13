using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandController : MonoBehaviour
{
    private bool moveLeft;
    private bool moveRight; 
    public GameObject sword;
    public GameObject shield;
    
    public void MoveRight () {

        Instantiate(shield);
        Destroy(sword);

    }
    public void MoveLeft () {

        Instantiate(sword);
        Destroy(shield);

    }

    void Update()
    {
        if (moveRight) {

            MoveRight ();
                        
        
        }
        if (moveLeft) {

            MoveLeft ();        
                       
            
        
        }
    }
}
