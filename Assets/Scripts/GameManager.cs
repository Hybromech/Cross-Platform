using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//! Manages the game
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public UI_manager uim;
    Locamotion loc;
    Ball ball;
    public fade fade;
    public Text framerate;
    public Text player_speed;
    public Text player_boost;
    public Text player_jump;
    public Text player_stars;
    //! Set Variables and start coroutinte update_fps
    void Start()
    {
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
            if (fade.alpha_value >= 1)//if is black.
            {
                SceneManager.LoadScene("Main_menu");//restart the game.
            }  
        }
    }
    //! Updates the fps every second.
    IEnumerator update_fps()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(1f);
        //Debug.Log("Updated fps display " + Time.time);
        framerate.text = (1.0f / Time.deltaTime).ToString();
        StartCoroutine(update_fps());
    }
}
