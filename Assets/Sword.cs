using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject swordLeft;
    [SerializeField] private GameObject swordRight;
    [SerializeField] private GameObject shieldLeft;
    [SerializeField] private GameObject shieldRight;

    void Start() {
        
        swordRight.SetActive(true);
        swordLeft.SetActive(false);
        shieldRight.SetActive(false);
        shieldLeft.SetActive(true);      
        
        
        
    }

    /*void Update() {
        if (swordRight.activeSelf == true) {
            TurnRight();

        }
        if (swordLeft.activeSelf == true) {
            TurnLeft();

        }
    }*/

    public void TurnRight () {
        if (swordLeft.activeSelf) {
            swordLeft.SetActive(false);
        }
        if (swordRight.activeSelf) {
            swordRight.SetActive(true);
        }
        if (shieldLeft.activeSelf) {
            shieldLeft.SetActive(false);
        }
        if (swordRight.activeSelf) {
            swordRight.SetActive(false);
        }

    }
    public void TurnLeft () {
         if (swordLeft.activeSelf) {
            swordLeft.SetActive(true);
        }
        if (swordRight.activeSelf) {
            swordRight.SetActive(false);
        }
        if (shieldLeft.activeSelf) {
            shieldLeft.SetActive(true);
        }
        if (swordRight.activeSelf) {
            swordRight.SetActive(true);
        }
    }
    
}
