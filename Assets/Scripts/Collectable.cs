using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//! Collectabe object
public class Collectable : MonoBehaviour
{
    [Tooltip("Powerup types are: 0 speed, 1 boost, 2 jump, 3 health, 4 time increase, 5 stars")]
    //! This instances type
    public int this_power_type;
    //! The type of powerup
    public enum power_type
    { 
        speed,
        boost,
        jump,
        health,
        time,
        stars
    }
    //!@brief Add powerup value when ball collides with the powerup
    //!@param Collider
    //!@return void
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball_player")
        {
            var loc = collision.gameObject.GetComponent<Locamotion>();
            var player = collision.gameObject.GetComponent<Ball>();
            switch (this_power_type)
            {
                case (int)power_type.speed:
                loc.torque += 0.1f;//add extra speed to player.
                break;
                    case (int)power_type.boost:
                    loc.boost_set += 0.1f;
                    break;
                        case(int)power_type.jump:
                        loc.jump_force += 1.5f;
                        break;
                            case (int)power_type.stars:
                            player.stars += 1;//Add another star to player
                            break;
            }
            Destroy(this.gameObject);
        }
    }
}
