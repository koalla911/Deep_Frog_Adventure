using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;
   public float topLimit = 10.0f;
   public float bottomLimit = -500.0f;
   public float followSpeed = 0.5f;

   void LateUpdate () {
       if (target != null) {
           Vector3 newPosition = this.transform.position;
           newPosition.y = Mathf.Lerp (newPosition.y, target.position.y, followSpeed);
           newPosition.y = Mathf.Min(newPosition.y, topLimit);
           newPosition.y = Mathf.Max(newPosition.y, bottomLimit);

           transform.position = newPosition;
       }
   }

   void OnDrawGizmosSelected() {
       Gizmos.color = Color.yellow;

       Vector3 topPoint = new Vector3(this.transform.position.x, topLimit, this.transform.position.z);
       Vector3 bottomPoint = new Vector3(this.transform.position.x, bottomLimit, this.transform.position.z);

       Gizmos.DrawLine(topPoint, bottomPoint);
   }
}
