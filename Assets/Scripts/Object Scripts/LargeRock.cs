using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRock : Object
{
    protected int keyIndex = 5;

    public override string[] getMessage()
    {
        //If interacting with the rock after talking with the birds
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            return stringToArray("That's a rock. A pretty big one, too. You don't see any hint of a 'secret shiny' as mentioned by the birds, though.");
        }
        //If interacting with the rock before talking with the birds
        else
        {
            return stringToArray("That's a rock. Your observation skills are unmatched.");
        }
    }
}
