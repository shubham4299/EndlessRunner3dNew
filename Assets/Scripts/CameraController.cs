using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private Vector3 moveVector;
    private float transition=0f;
    private float animationDuration = 2f;
    private Vector3 animationOffset=new Vector3(0,5,5);

    void Start()
    {
        offset = transform.position-target.position;
    }

   /* void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = newPosition;
    }*/

   private void Update()
    {
        moveVector= target.position + offset;
        moveVector.x = 0;
        //moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        if (transition > 1)
        {
            transform.position = moveVector;
        }
        else
        {
            transform .position = Vector3.Lerp(moveVector + animationOffset,moveVector,transition); //start cinematic animation
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(target.position + Vector3.up);
        }
        
    }
}
