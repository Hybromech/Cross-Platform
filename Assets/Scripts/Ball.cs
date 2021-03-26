using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//! Handles game logic for the ball
/**
 * Destoyes the ball if the win condition or death condition passes
 */
public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    //! Number of stars
    public int stars = 0;
    //! Update win/lose condition.
    void Update()
    {
        if (stars == 5)
        {
            print("You have all the stars congrats you win!");
            Destroy(this.gameObject);
        }
        if (transform.position.y <= -56.4)
        {
            Destroy(this.gameObject);
        }
    }
    /**
   @brief Destroy the ball if collided with cactus
   @param Collision
   @return void 
   */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cactus")
        {
            Debug.Log("Hit Cactus");
            Destroy(this.gameObject);
        }
    }
}
