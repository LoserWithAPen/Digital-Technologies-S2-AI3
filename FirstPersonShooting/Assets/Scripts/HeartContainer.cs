using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartContainer : MonoBehaviour
{
    //A single list to change all of our hearts
    public HeartContainer next;

    //How full the container is
    [Range(0, 1)] float fill;
    [SerializeField] Image fillImage;

    public void SetHeart(float count)
    {
        fill = count; //Get how much we are filling our container by
        fillImage.fillAmount = fill; //Changes the the fill in the UI
        count--; //Reduces count by one (how much we just used filling the last heart)
        if(next != null) //Checks if we have more hearts
        {
            next.SetHeart(count); //Fills the next heart by count
        }
    }

}

/*
 * This script (As I understand it)
 * 1) Makes a list of all our hearts
 * 2) Registers how full each heart is
 * 3) Fills or empties hearts based on count
 * 4) If necessary, reduces or fills the next heart in order
*/