using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Handles user input
/**
 * Has a function to pass input into and returns true if that input is valid. 
 */
public class Input_manager : MonoBehaviour
{
    //! Stores values for different types of movement.
    public enum input
    {
        forward,
        back,
        left,
        right,
        boost,
        brake,
        jump,
        noInput
    }
   //Implement Gamepad.
   //!@brief returns true if the input value passed in matches a key press. 
   //!@param enum
   //!@return bool
    public bool Get_input(input i)
    {
        var temp = input.noInput;
        if (Input.GetKey(KeyCode.W))
        temp = input.forward;

        if (Input.GetKey(KeyCode.S))
        temp = input.back;

        if (Input.GetKey(KeyCode.A))
        temp = input.left;

        if (Input.GetKey(KeyCode.D))
        temp = input.right;

        if (Input.GetKey(KeyCode.LeftControl))
            temp = input.boost;
        
        if (Input.GetKey(KeyCode.C))
            temp = input.brake;
        
        if (Input.GetKeyDown(KeyCode.Space))
            temp = input.jump;

        if (i == temp)
        {
            return true;
        }
        else return false;
    }

}
