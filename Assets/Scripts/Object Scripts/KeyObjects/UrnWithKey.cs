using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrnWithKey : Urn
{
    private int updateKeyIndex = 12;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with urn after acquiring shovel
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                string[] dialogue = new string[2];
                dialogue[0] = "You suck up your pride and apologize to the spirit of the person whose ashes you're about to ravage before shoving your hand into the pot. To your surprise, you feel a piece of paper at the very bottom of the pot.";
                dialogue[1] = "You pull it out. On the parchment is a messy, scribbled drawing of a toppled well. Smack dab in the center is a big 'X'.";
                return dialogue;
            }
            else
            {
                return stringToArray("You've already sifted though this urn. You're not doing it again. But, you pull out the parchment again. On the parchment is a messy, scribbled drawing of a toppled well. Smack dab in the center is a big 'X'.");
            }
            
        }
        //If interacting with urn before acquiring shovel
        else
        {
            return stringToArray("You look inside the urn. It's filled with grey ash. You're not too inclined to sift through someone's ashes.");
        }
    }
}
