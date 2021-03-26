using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(CinemachineFreeLook))]
//!Modifies the cinemachine camera
/**
 * Modify the X_look and Y_look to change the movespeed of the camera
 */
public class Camera_Look : MonoBehaviour
{
    //! A reference to the CinemachineFreeLook
    private CinemachineFreeLook cinemachine;
    //! A reference to Joystick
    public Joystick joystick;
    //! The X modifer
    public float X_look_speed_modifer;
    //! The Y modifer
    public float Y_look_speed_modifer;
    //! Set variables
    void Start()
    {
        cinemachine = GetComponent<CinemachineFreeLook>();
    }
    //! Modify the X and Y value of the CinemachineFreeLook based on joystick input.
    void Update()
    {
        cinemachine.m_XAxis.Value += joystick.Horizontal * X_look_speed_modifer;
        cinemachine.m_YAxis.Value += joystick.Vertical * Y_look_speed_modifer;
    }
}

