using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private Vector3 moveToPos;
    private Vector3 thisStartPos;
    private Transform thisTransform;

    private Camera cam;

    private Vector3 curMoveVel;
    private Vector3 curRotVel;

    
    [SerializeField] 
    private float rotateToMouseTime = 1;
    
    [SerializeField] 
    private float moveToMouseTime = 5;

    void Start()
    {
        thisStartPos = transform.position;
        thisTransform = transform;
        cam = Camera.main;
    }

    void Update()
    {
     FollowMouse();   
    }

    void FollowMouse()
    {
        Rect screenRect = new Rect(0,0, Screen.width, Screen.height);
        if (!screenRect.Contains(Input.mousePosition))
        {
            return;
        }

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 100))
        {
           moveToPos = new Vector3(hit.point.x, thisStartPos.y, hit.point.z);
        }

        var position = thisTransform.position;
        var smoothPos = Vector3.SmoothDamp(position, moveToPos, ref curMoveVel, moveToMouseTime);
        position = smoothPos;
        thisTransform.position = position;
        var targetRotation = Quaternion.LookRotation(moveToPos - position);

        // thisTransform.LookAt(moveToPos);
        // var rotSmooth = Vector3.SmoothDamp(thisTransform)
        thisTransform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateToMouseTime * Time.deltaTime);
    }
}
