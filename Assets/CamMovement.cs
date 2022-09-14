using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    public Vector3 minVal, maxVal;
   
    private void FixedUpdate()
{
     Follow();
}

void Follow()
{
    Vector3 targetPosition = target.position+offset;

    Vector3 boundPosition = new Vector3(
        Mathf.Clamp(targetPosition.x, minVal.x, maxVal.x),
        Mathf.Clamp(targetPosition.y, minVal.y, maxVal.y),
        Mathf.Clamp(targetPosition.z, minVal.z, maxVal.z));


    Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
    transform.position = smoothPosition;


}
}
