using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController : MonoBehaviour
{
    private bool moveLeft;
    private bool moveRight; 
    public GameObject sword;
    public GameObject shield;
    
    public void MoveRight () {

        Instantiate(sword);
        Destroy(shield);

    }
    public void MoveLeft () {

        Instantiate(shield);
        Destroy(sword);

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
