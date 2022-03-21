using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations charAnimations;


    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotationSpeed = 0.15f;
    public float rotateDeg = 180f;
    
    void Awake() 
    {
        charController = GetComponent<CharacterController>();
        charAnimations = GetComponent<CharacterAnimations>();
    }

    void OnEnable() 
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move() 
    {
        if (Input.GetAxis(Axes.VerticalAxis)>0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection*movement_Speed*Time.deltaTime);
        }
        else if (Input.GetAxis(Axes.VerticalAxis)<0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection*movement_Speed*Time.deltaTime);
        }
        else
        {
            charController.Move(Vector3.zero);
        }
    }

    void Rotate()
    {
        Vector3 rotDir = Vector3.zero; 
        if(Input.GetAxis(Axes.HorizontalAxis)>0)
        {
            rotDir = transform.TransformDirection(Vector3.right);
        }
        if(Input.GetAxis(Axes.HorizontalAxis)<0)
        {
            rotDir = transform.TransformDirection(Vector3.left);
        }

        if(rotDir!=Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotDir), rotateDeg*Time.deltaTime);
        }
    }

    void AnimateWalk()
    {
        if(charController.velocity.sqrMagnitude > 0f)
        {
            charAnimations.Walk(true);
        }
        else
        {
            charAnimations.Walk(false);
        }
    }
}
