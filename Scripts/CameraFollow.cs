using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private bool activeMove;
    
    [SerializeField]
    private Vector3 offset;
    // Start is called before the first frame update
    void Awake()
    {
       target = GameObject.FindGameObjectWithTag(Tags.PlayerTag).transform;
       
       activeMove = true; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(activeMove)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        transform.position = target.TransformPoint(offset);

        transform.rotation = target.rotation;
    }

    public void FreezeMovement()
    {
        target = null;
    }

}
