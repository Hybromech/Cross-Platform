using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Locamotion script created by Andrew S Jonas
// Last edited 17/03/2021
//! Responsible for ball movement
/**
 * Adds forces to the ball for movement and jumping, includes logic for setting the boost switch
 * and checking for the grounded condition.
 */
public class Locamotion : MonoBehaviour
{
    //! Max speed of the ball.
    public float max_speed;
    //! The jump force of the ball.
    public float jump_force;
    //!Vector to plug into jumping force
    private Vector3 jump_vector;
    //! The current forward speed.
    public float current_forwardSpeed;
    //! The amount of torque to multiple with input axis.
    public float torque;
    //! The amount of force to add for boosting.
    public float boost_set;
    //!The maximum angular velocity the ball can reach.
    public float maxAngularVelocity;
    //! Whether the ball can boost
    public bool is_boost = false;
    //! Whether the ball is currently grounded or not.
    public bool is_grounded = false;
    //! A reference to the cameras transform for directing the balls motion
    public Transform cam;
    //! A reference to the Joystick class
    public Joystick joystick;//Touch Joystick
    //! A reference to imput manager.
    private Input_manager input_manager;
    //! A reference to the rigid body.
    private Rigidbody rb;
    //! A reference to the orient master.
    GameObject orient_master;
    //! Assign variables
    void Start()
    {
        // Set the gravity
        Physics.gravity = new Vector3(0, -50f, 0);
        // Get the input manager component.
        input_manager = GetComponent<Input_manager>();
        // Get the rigid body component
        rb = GetComponent<Rigidbody>();
        // Set the jump vectors Y component to jump force.
        jump_vector = new Vector3(0, jump_force, 0);
        // Set rigid bodies maxAngularVelocity
        rb.maxAngularVelocity = maxAngularVelocity;      
    }
    //! Update whether the ball should jump
    void Update()
    {
        //Debug.Log("rb.angularVelocity " + rb.angularVelocity);
        //Debug.Log("rb.Velocity " + rb.velocity);
        Set_boost();
        is_grounded = Is_grounded();//Set is grounded
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))//only check on the frame the user press jump
        {
            print("Player pushed the jump key");
            print("is_grounded is " + is_grounded);
            if (is_grounded == true)
            {
                print("Jumping");
                Jump();
            }
        }
    }
    //! Update movement of the ball.
    void FixedUpdate()
    {
        var localVelocity = transform.InverseTransformDirection(rb.velocity);
        current_forwardSpeed = localVelocity.z;//Extract the current local velocity.
        Propel();
    }
    /**
    @brief Add forces to the ball in the direction of the camera
    @param none
    @return void 
    */
    private void Propel()
    {
        //float hor_axis = joystick.Horizontal;
        //float vert_axis = joystick.Vertical;
            //Get input
            float hor_axis = Input.GetAxis("Horizontal");
            float vert_axis = Input.GetAxis("Vertical");
            Debug.Log("hor_axis" + hor_axis);
            Debug.Log("vert_axis" + vert_axis);
      try {
            //Get the vector of direction
            Vector3 direction = new Vector3(vert_axis, 0f, -hor_axis).normalized;
            //Check if there is input
            if (direction.magnitude >= 0.1f)
            {
                //Get the target angle
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                //Set the move direction vector
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //Apply torque
                rb.AddTorque(moveDir.normalized * (torque), ForceMode.VelocityChange);
                rb.AddTorque(moveDir.normalized * (torque), ForceMode.VelocityChange);
            }
          }

        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
        //Debug.Log("vert_axis " + vert_axis);
        //if (is_grounded)//Movement by force code
        //{
        //    print("Updating force input");
        //    rb.AddForce(orient_master.transform.right * (hor_axis) * 1 / 2, ForceMode.VelocityChange);//need to swap forwards and right.
        //    rb.AddForce(orient_master.transform.forward * vert_axis * 1 / 2, ForceMode.VelocityChange);
        //}
        //else print("Not Updating force input");
        //Add torque


        //Add boost force
        if (is_boost)//&& is_grounded)
        {
            print("Adding boost force");
            rb.AddForce(cam.right * (hor_axis) * boost_set, ForceMode.VelocityChange);//need to swap forwards and right.
            rb.AddForce(cam.forward * vert_axis * boost_set, ForceMode.VelocityChange);
        }
        //if (current_forwardSpeed > max_speed || current_forwardSpeed < -max_speed)
        //{
           
        //}
    }
    /**
    @brief Update whether the boost is active.
    @param none
    @return void 
    */
    private void Set_boost()
    {
        if (input_manager.Get_input(Input_manager.input.boost))//if boost key is pressed.
        {
            is_boost = true;
            Debug.Log("boost_pushed");
        }
        else
        {
            is_boost = false;
        }
    }
    /**
    @brief Add an upwards force to the ball.
    @param none
    @return void 
   */
    private void Jump()
    {
        //if the user pushes jump key add an upward force to the ball as long as the ball is grounded.
        jump_vector = new Vector3(0, jump_force, 0);
        rb.AddForce(jump_vector, ForceMode.VelocityChange);//Add an upwards force. 
    }
    /**
    @brief Update whether the ball is grounded
    @param none
    @return void 
   */
    private bool Is_grounded()
    {
        //Check if on the ground.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (Vector3.up) * -1, out hit, 3f))//fire a raycast down.
        {
            Debug.Log("Raycast hit" + hit.collider.gameObject.name);
            return true;   
        }
        else
            return false;
    }
}