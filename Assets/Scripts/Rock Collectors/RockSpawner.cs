using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] rocks;

    private float distanceBetweenRocks = 3f;

    private float minX, maxX;

    private float lastRockPositionY;
    private float controlVertical;

    [SerializeField] private GameObject[] collectables;

    private GameObject player;

    private void Awake()
    {
        controlVertical = 0;
        SetMinAndMaxX();
        RocksCreate();

    }

    private void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    private void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temporary = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temporary;

            /* GameObject temp = arrayToShuffle[i];
            - arrayToShuffle[i] = 3; 
            meaning temp = 3;
            arrayToShuffle[i] = arrayToShuffle[random]; , it had a value of arrayToshuffle[i] = 3
            thats why we saved it in our temp
            now we take arrayToShuffle[random] which at the moment has a value of 5 e.g arrayToShuffle[random] = 5;
            arrayToShuffle[random] = temp;*/
        }
    }

    private void RocksCreate()
    {
        Shuffle(rocks);

        float positionY = 0f;

        for (int i = 0; i < rocks.Length; i++)
        {
            Vector3 temporary = rocks[i].transform.position;

            temporary.y = positionY;

            if (controlVertical == 0)
            {
                temporary.x = Random.Range(0.0f, maxX);
                controlVertical = 1;
            }
            else if (controlVertical == 1)
            {
                temporary.x = Random.Range(0.0f, minX);
                controlVertical = 2;
            }
            else if (controlVertical == 2)
            {
                temporary.x = Random.Range(1.0f, maxX);
                controlVertical = 3;
            }
            else if (controlVertical == 3)
            {
                temporary.x = Random.Range(-1.0f, minX);
                controlVertical = 0;
            }

            lastRockPositionY = positionY;

            rocks[i].transform.position = temporary;

            positionY -= distanceBetweenRocks;

        }

    }

    private void PositionThePlayer()
    {
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] rocksInGame = GameObject.FindGameObjectsWithTag("Rocks");

        for(int i = 0; i < spikes.Length; i++)
        {
            if(spikes[i].transform.position.y == 0f)
            {
                Vector3 t = spikes[i].transform.position;

                spikes[i].transform.position = new Vector3(rocksInGame[0].transform.position.x, rocksInGame[0].transform.position.y, rocksInGame[0].transform.position.z);
                
                rocksInGame[0].transform.position = t;
            }            
        }
        
        Vector3 temporary = rocksInGame[0].transform.position;

        for (int i = 1; i < rocksInGame.Length; i++)
        {
            if (temporary.y < rocksInGame[i].transform.position.y)
            {
                temporary = rocksInGame[i].transform.position;
            }
        }

        temporary.y += 1f;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Rock" || target.tag == "Deadly")
        {
            if (target.transform.position.y == lastRockPositionY)
            {
                Shuffle(rocks);
                Shuffle(collectables);

                Vector3 temporary = target.transform.position;
                
                for (int i =0; i < rocks.Length; i++)
                {
                    if (!rocks[i].activeInHierarchy)
                    {
                        if (controlVertical == 0)
                        {
                            temporary.x = Random.Range(0.0f, maxX);
                            controlVertical = 1;
                        }
                        
                        else if (controlVertical == 1)
                        {
                            temporary.x = Random.Range(0.0f, minX);
                            controlVertical = 2;
                        }
                        
                        else if (controlVertical == 2)
                        {
                            temporary.x = Random.Range(1.0f, maxX);
                            controlVertical = 3;
                        }
                        
                        else if (controlVertical == 3)
                        {
                            temporary.x = Random.Range(-1.0f, minX);
                            controlVertical = 0;
                        }

                        temporary.y -= distanceBetweenRocks;

                        lastRockPositionY = temporary.y;

                        rocks[i].transform.position = temporary;
                        rocks[i].SetActive(true);
                    }
                }

            }
        }
    }
}
