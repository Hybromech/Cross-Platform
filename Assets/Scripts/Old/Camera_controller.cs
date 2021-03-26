using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!Camera Controller
public class Camera_controller : MonoBehaviour
{
    public Vector3 temp_vector;
    //! Shoud the camera reset.
    public bool should_reset;
    //! Value to modify the rotation of the camera
    public float Rotation_angle_increment;
    Quaternion camera_reset;
    Transform temp;
    void Start()
    {
        camera_reset = transform.rotation;
    }
    //! Rotate the camera based on input.
    void Update()
    {
            //Horrizontal camera rotation
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0, -Rotation_angle_increment, 0, Space.Self);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0, Rotation_angle_increment, 0, Space.Self);
            //Vertical camera rotation
            if (Input.GetKey(KeyCode.UpArrow))
                transform.Rotate(Rotation_angle_increment, 0, 0, Space.Self);
            if (Input.GetKey(KeyCode.DownArrow))
                transform.Rotate(-Rotation_angle_increment, 0, 0, Space.Self);
        
        
        //Reset Camera
        if (Input.GetKey(KeyCode.RightControl))
        {
            temp_vector = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            //print("temp_vector" + temp_vector);
            var targetRotation = Quaternion.LookRotation(temp_vector, Vector3.up);
            //Debug.Log("transform.rotation" + transform.rotation);
            //Debug.Log("targetRotation" + targetRotation);
            Debug.Log("transform.rotation.x" + Mathf.Abs(transform.rotation.x));// + Mathf.Abs(transform.rotation.y) + Mathf.Abs(transform.rotation.z) + "target.rotation" + Mathf.Abs(targetRotation.x)  + Mathf.Abs(targetRotation.y)  + Mathf.Abs(targetRotation.z));
            Debug.Log("target.rotation.x" + Mathf.Abs(targetRotation.x));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
            //if (transform.rotation == targetRotation)
            //if (Mathf.Abs(transform.rotation.x) == Mathf.Abs(targetRotation.x) && Mathf.Abs(transform.rotation.y) == Mathf.Abs(targetRotation.y) && Mathf.Abs(transform.rotation.z) == Mathf.Abs(targetRotation.z))
            //{
            //    should_reset = false;
            //}
        }
        //transform.rotation.SetLookRotation(temp_vector);
        //temp.rotation.SetLookRotation(temp_vector, Vector3.up);
        //transform.LookAt(temp_vector, Vector3.up);
        //Vector3 reset = new Vector3(transform.rotation.x, camera_reset.eulerAngles.y, transform.rotation.z);
        //transform.Rotate(reset,Space.Self);
    }
}
