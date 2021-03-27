using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//! Manages the game and updates variables to the user interface
/**
 * Manages game logic such as checking to see if the player is dead and loading appropriate scenes.
 * Updates variables to the user interface.
 */
public class GameManager : MonoBehaviour
{
    //! A reference to the player object
    public GameObject player;
    //! A reference to UI manager
    public UI_manager uim;
    //! A reference to Locamotion
    Locamotion loc;
    //! A referece to ball
    Ball ball;
    //! A referece to fade
    public fade fade;
    //! A Text object that draws the framerate
    public Text framerate;
    //! A Text object that draws the the players speed attribute
    public Text player_speed;
    //! A Text object that draws the players boost attribute
    public Text player_boost;
    //! A Text object that draws the players jump attribute
    public Text player_jump;
    //! A Text object that draws the players stars attribute
    public Text player_stars;
    //! Set Variables and start coroutinte update_fps
    void Start()
    {
        //Debug.Log("minSdkVersion" + UnityEditor.PlayerSettings.Android.minSdkVersion.ToString());
        loc = player.GetComponent<Locamotion>();
        ball = player.GetComponent<Ball>();
        StartCoroutine(update_fps());
    }
    //! Handle UI and game logic
    void Update()
    {
        player_speed.text = loc.torque.ToString();
        player_jump.text = loc.jump_force.ToString();
        player_stars.text = ball.stars.ToString();
        player_boost.text = loc.boost_set.ToString();
        if (ball.stars >= 5)//if player is dead.
        {
            fade.fade_out = true;//fade out.
            uim.show_victory();
            fade.alpha_mod = 0.0009f;
            if (fade.alpha_value >= 1)//if is black.
            {
                SceneManager.LoadScene("Main_menu");//restart the game.
            }
        }
        if (player == null)//if player is dead.
        {
            fade.fade_out = true;//fade out.
            fade.alpha_mod = 0.001f;
            if (fade.alpha_value >= 1)//if is black.
            {
                SceneManager.LoadScene("Main_menu");//restart the game.
            }  
        }
    }
    //! Updates the fps counter on screen.
    IEnumerator update_fps()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(1f);
        //Debug.Log("Updated fps display " + Time.time);
        framerate.text = (1.0f / Time.deltaTime).ToString();
        StartCoroutine(update_fps());
    }
}
