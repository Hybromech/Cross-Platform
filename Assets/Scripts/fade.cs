using UnityEngine;
using UnityEngine.UI;

//! Fades the screen to or from black
/**
 * Fades the screen to or from black, you can customise the fading behaviour with fade_out and alpha_mod.
 */
public class fade : MonoBehaviour
{
    //! Should the script fade out.
    public bool fade_out;
    //! Value to modify the current alpha value.
    public float alpha_mod = 0.01f;
    //! Reference to the image component.
    private Image image;
    //! A color struct used to store the new colour after the alpha is modified.
    private Color newcolor;
    //! The current alpha value of the colour
    public float alpha_value;
    //! Assign variables
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.enabled = true;
        newcolor = image.color;
        alpha_value = newcolor.a;
    }
    //! Fade in or out
    void Update()
    {
        if (fade_out)
        {
            if (alpha_value <= 1)//if not yet black
            {
                Debug.Log("Fading to black" + alpha_value);
                alpha_value += alpha_mod;
                newcolor = new Color(0, 0, 0, alpha_value);
                image.color = newcolor;
            }     
        }
        else if (alpha_value > 0)//if is not clear
        {
        
            Debug.Log("Fading to clear" + alpha_value);
            alpha_value -= alpha_mod;
            newcolor = new Color(0, 0, 0, alpha_value);
            image.color = newcolor;
        }    
    }
}
