using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Object
{
    private int keyIndex = 7;
    private bool interacted = false;

    public override string[] getMessage()
    {
        //If interacting with crate after acquiring crowbar
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                interacted = true;
                return stringToArray("You pry open the crate with the rusty crowbar you found. Unfortunately, there's nothing but dust and rotting wood inside.");
            }
            else
            {
                return stringToArray("You've already opened this one. Still nothin'.");
            }
        }
        //If interacting with crate before acquiring crowbar
        else
        {
            return stringToArray("This is a regular, wooden crate. The lid is attached tight. Maybe if you had a crowbar or something you could open it...");
        }
    }
}
