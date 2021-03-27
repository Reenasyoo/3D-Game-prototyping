using System;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody = null;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private CharacterAnimationController animationController = null;
    [SerializeField] private PlayerSettings settings;


    private float sprintSpeed = 2f;
    
    
    private bool grounded = false;


    private void Awake()
    {


    }
    
    
    


    private void Update()
    {
        var inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animationController.SetForwardVelocity(inputDirection.z * sprintSpeed);        
            }
            else
            {
                {
                    animationController.SetForwardVelocity(inputDirection.z);
                }
            }
            
            animationController.SetSideVelocity(inputDirection.x);


            if(_rigidbody.velocity.y.Equals(0f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (grounded)
        {
            var direction = transform.TransformDirection(inputDirection);
        
            direction *= settings.moveSpeed;

            _rigidbody.velocity = direction;
        }

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            var up = Vector3.up * settings.jumpHeight;
            _rigidbody.AddForce(up, ForceMode.Impulse);
        }


        RotateCharacterForward();
    }

    private void RotateCharacterForward()
    {
        var distance = 0f;
        var direction = 0f;
        var rotation = transform.rotation;
        var cameraRotation = mainCamera.rotation;

        if (Aprox(rotation.y, cameraRotation.y, 0.1f))
        {
            if (rotation.y > cameraRotation.y)
            {
                distance = rotation.y - cameraRotation.y;
                direction = 0;
            }
            else if (rotation.y < cameraRotation.y)
            {
                direction = cameraRotation.y - rotation.y;
                direction = 2;
            }
        }
        else
        {
            direction = 1;
        }

        var targetRotation = Quaternion.Lerp(rotation, cameraRotation, Time.deltaTime * settings.rotationSpeed);

        targetRotation.x = 0;
        targetRotation.z = 0;

        transform.rotation = targetRotation;

    }

    private bool Aprox(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }
}
