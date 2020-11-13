using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    private GameObject[] backgrounds;

    private float lastVerticalBorder;

    private void Start()
    {
        GetBackgroundSetBorder();
    }

    private void GetBackgroundSetBorder()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");

        lastVerticalBorder = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (lastVerticalBorder > backgrounds[i].transform.position.y)
            {
                lastVerticalBorder = backgrounds[i].transform.position.y;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            if(target.transform.position.y == lastVerticalBorder)
            {
                Vector3 temporary = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temporary.y -= height;

                        lastVerticalBorder = temporary.y;

                        backgrounds[i].transform.position = temporary;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
