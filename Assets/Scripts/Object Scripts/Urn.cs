using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urn : Object
{
    protected int keyIndex = 11;
    private bool interacted = false;

    public override string[] getMessage()
    {
        //If interacting with urn after acquiring shovel
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                interacted = true;
                return stringToArray("You suck up your pride and apologize to the spirit of the person whose ashes you're about to ravage before shoving your hand into the pot. To your dismay, you find nothing.");
            }
            else
            {
                return stringToArray("You've already sifted though this urn. You're not doing it again.");
            }
            
        }
        //If interacting with urn before acquiring shovel
        else
        {
            return stringToArray("You look inside the urn. It's filled with grey ash. You're not too inclined to sift through someone's ashes.");
        }
    }
}
