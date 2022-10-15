using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Object
{
    protected int keyIndex = 7;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with the barrel after acquiring the crowbar
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                interacted = true;
                return stringToArray("You pry off the barrel's lid with the rusty crowbar you found. Unfortunately, there's nothing but dust and rotting wood inside.");
            }
            else
            {
                return stringToArray("You've already opened this one. Still nothin'.");
            }
        }
        //If interacting with the barrel before acquiring the crowbar
        else
        {
            return stringToArray("You inspect the barrel. It's old and weathered, but the lid is still shut tight. Maybe if you had a crowbar or something you could open it...");
        }
    }
}
