using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    [HideInInspector]
    public bool moveCamera;

    private void Update()
    {
        if (moveCamera)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        Vector3 temporary = transform.position;

        float oldY = temporary.y;
        float newY = temporary.y - (speed * Time.deltaTime);

        temporary.y = Mathf.Clamp(temporary.y, oldY, newY);

        transform.position = temporary;

        speed += acceleration * Time.deltaTime;

        /*if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }*/
    }
}
