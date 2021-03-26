using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//! Enemy object
/**
 * This object will kill the player upon collision
 */
public class cactus : MonoBehaviour
{
    // Start is called before the first frame update
    //! A reference to the rigid body
    public Rigidbody rb;
    //! A reference to the collider
    public Collider col;
    //!Assign variables
    void Start()
    {
        var y = col.bounds.size.y;
        Vector3 offset = new Vector3(0, y / -2.0f, 0);
        rb.centerOfMass = offset;
    }
}
