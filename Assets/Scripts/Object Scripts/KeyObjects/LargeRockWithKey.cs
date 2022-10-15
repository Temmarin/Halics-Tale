using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRockWithKey : LargeRock
{
    private int updateKeyIndex = 6;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with the rock after talking with the birds
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                return stringToArray("That's a rock. A pretty big one, too. You see a glint from a deep crack in it's surface. You manage to pry out the object, and realize you're in possession of a key!");
            }
            else
            {
                return stringToArray("Now that you've pried the key out, this is, once again, nothing more than a big rock.");

            }
        }
        //If interacting with the rock before talking with the birds
        else
        {
            return stringToArray("That's a rock. Your observation skills are unmatched.");
        }
    }
}
