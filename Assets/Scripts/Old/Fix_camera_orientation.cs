using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fix_camera_orientation : MonoBehaviour
{
    public GameObject cam_target;
    void LateUpdate()
    {
        transform.position = cam_target.transform.position;
    }
}
