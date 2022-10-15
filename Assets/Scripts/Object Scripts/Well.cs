using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : Object
{
    protected int keyIndex = 12;
    private bool interacted = false;

    public override string[] getMessage()
    {
        //If interacting with well after acquiring treasure map
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                interacted = true;
                return stringToArray("You dig up the ground in the center of the well. You find nothing.");
            }
            else
            {
                return stringToArray("You've already dug here. Still nothin',");
            }
        }
        //If interacting with well before acquiring treasure map
        else
        {
            return stringToArray("You look at the old, destroyed well. It must've been filled long, long ago.");
        }
    }
}
