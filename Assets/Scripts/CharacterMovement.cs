using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float playerSpeed = 10.0f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Joystick joy;
    // Start is called before the first frame update
    private void Awake()
    {
       
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //WASD

        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
        float axisCombined = axisY / axisX;
        Vector3 keyMovement = new Vector3(axisX, 0.0f, axisY);
        
        

        //joystick

        float joyAxisX = joy.Horizontal;
        float joyAxisY = joy.Vertical;
        float joyAxisCombined = joyAxisY / joyAxisX;
        Vector3 joyMovement = new Vector3(joyAxisX, 0.0f, joyAxisY).normalized;
        Vector3 movement= keyMovement==Vector3.zero?joyMovement:keyMovement;
        rb.velocity = movement * playerSpeed;
        animator.SetFloat("Blend", movement.magnitude);
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);

            if (axisCombined >= 0.1f || axisCombined <= 0.1f)
            {

                transform.rotation = Quaternion.Slerp
                    (transform.rotation, newRotation, 20 * Time.deltaTime);

            }
            if (joyAxisCombined >= 0.1f || joyAxisCombined <= 0.1f)
            {

                transform.rotation = Quaternion.Slerp
                    (transform.rotation, newRotation, 20 * Time.deltaTime);

            }
        }
        //rb.velocity = joyMovement * playerSpeed;
        //animator.SetFloat("Blend", joyMovement.magnitude);
        //if (joyMovement != Vector3.zero)
        //{
        //    //Quaternion newRotation = Quaternion.LookRotation(joyMovement);


            
        //}


    }
}
