using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float playerSpeed = 10.0f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
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
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");
        float axisCombined = axisY / axisX;

        Vector3 movement = new Vector3(axisX , 0.0f, axisY);
        rb.velocity = movement*playerSpeed;
        animator.SetFloat("Blend", movement.magnitude);
        //rb.AddForce(movement * playerSpeed, ForceMode.Impulse);
        if (movement != Vector3.zero )
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);


            if (axisCombined >= 0.1f || axisCombined <= 0.1f)
            {

                transform.rotation = Quaternion.Slerp
                    (transform.rotation, newRotation, 20 * Time.deltaTime);

            }
        }
    }
}
