using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!Applies a rotation to objects
/**
 * Applies a torque to game objects to the axis specifed by rotation_pivot
 */
public class torque : MonoBehaviour
{
    //! Reference to the rigid body
    private Rigidbody rb;
    //! The value multiplied by the torque.
    public float torque_;
    //! The max angular velocity.
    public float maxAngularVelocity;
    //! the axis the object should rotate around.
    public string rotation_pivot;
    //! Assign variables
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;
    }
    //! Add torque to the object on specifed rotation axis.
    void Update()
    {
        if (rotation_pivot == "x")
        {
            rb.AddRelativeTorque(Vector3.right * torque_, ForceMode.VelocityChange);
        }
        if (rotation_pivot == "y")
        {
            rb.AddRelativeTorque(Vector3.up * torque_, ForceMode.VelocityChange);
        }
        if (rotation_pivot == "z")
        {
            rb.AddRelativeTorque(Vector3.forward * torque_, ForceMode.VelocityChange);
        }
    }
}
