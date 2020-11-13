using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Rock" || target.tag == "Deadly")
        {
            target.gameObject.SetActive(false);
        }
    }
}
