using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//! Manages user interface
/**
 * Loads a scene depending on which button the user pressed.
 * Provides a function to display the winning image.
 */
public class UI_manager : MonoBehaviour
{
    //! Object that draws the winning image.
    public GameObject win_obj;
    //! Image component for win_obj
    private Image win_image;
    //! Get the win objects Image component
    private void Start()
    {
        if (win_obj != null)
        {
            win_image = win_obj.GetComponent<Image>();
        }
    }
    /**
    @brief Start the game
    @param none
    @return void 
    */
    public void button_start()
    {
        SceneManager.LoadScene("Scene6");//start the game.
    }
    /**
    @brief Display the win image
    @param none
    @return void 
    */
    public void show_victory()
    {
        win_image.enabled = true;
    }
    /**
    @brief Exit the game
    @param none
    @return void 
    */
    public void button_quit()
    {
        Application.Quit(0);//quit the game.
    }
    /**
    @brief Load the help menu
    @param none
    @return void 
    */
    public void button_help()
    {
        SceneManager.LoadScene("Help_menu");//start the game.
    }
    /**
    @brief Load the main menu
    @param none
    @return void 
    */
    public void button_main()
    {
        SceneManager.LoadScene("Main_menu");//start the game.
    }
    /**
    @brief Load the credits menu
    @param none
    @return void 
    */
    public void button_credits()
    {
        SceneManager.LoadScene("Credits");//start the game.
    }
}
