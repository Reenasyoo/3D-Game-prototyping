using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody = null;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private CharacterAnimationController animationController = null;
    [SerializeField] private PlayerSettings settings;

    private List<PickupObject> pickedUpObjects = new List<PickupObject>();
    private GameObject targetObject;
    private Transform targetPlace;
    private int targetPlaceIndex;
    private bool canPickup = false;
    private bool canDrop = false;
    private bool oneAction = true;


    private float sprintSpeed = 2f;
    private bool grounded = false;
    
    

    private void Pickup()
    {
        var temp = targetObject.GetComponent<PickupObject>();;
        var pickupObj = temp;

        if (pickupObj.canPickup)
        {
            pickupObj.canPickup = false;
            temp.gameObject.SetActive(false);
            pickedUpObjects.Add(temp);    
        }
    }

    private bool HasObject(int index)
    {
        var has = false;
        
        foreach (var pickedUpObject in pickedUpObjects)
        {
            if (pickedUpObject.index == index)
            {
                has = true;
            }
        }

        return has;
    }

    private void Drop()
    {
        if(pickedUpObjects.Count <= 0) return;

        if (HasObject(targetPlaceIndex))
        {
            var temp = targetPlace.GetChild(0);
            temp.gameObject.SetActive(true);
        
            pickedUpObjects.Remove(pickedUpObjects[0]);    
        }
    }

    private void Update()
    {
        if (canPickup)
        {
            if (Input.GetKey(KeyCode.E) && oneAction)
            {
                
                canPickup = false;
                oneAction = false;
                Pickup();
            }
        }
        
        if (canDrop)
        {
            if (Input.GetKey(KeyCode.E) && oneAction)
            {
                oneAction = false;
                canDrop = false;
                Drop();
                
            }
        }
        
        
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


        if (_rigidbody.velocity.y.Equals(0f))
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(("Pickup")))
        {
            canPickup = true;
            targetObject = other.gameObject;
        }

        if (other.CompareTag("DropPoint"))
        {
            targetPlace = other.transform;
            targetPlaceIndex = other.gameObject.GetComponent<DropPlace>().index;
            canDrop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(("Pickup")))
        {
            canPickup = false;
            targetObject = null;
            oneAction = true;
        }
        
        if (other.CompareTag("DropPoint"))
        {
            canDrop = false;
            oneAction = true;
        }
    }
}