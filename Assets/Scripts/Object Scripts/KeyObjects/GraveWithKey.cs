using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveWithKey : Grave
{
    private int keyIndex = 8;
    private int updateKeyIndex = 9;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with grave after obtaining the letter
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                string[] dialogue = new string[2];
                dialogue[0] = "You look at the grave. Although the words etched into the stone are worn and faded, you're just barely able to make out what they say...";
                dialogue[1] = "'Here Lies Robert, Awaiting The Day He Might Meet Matilda Again Under The Tree Where They First Met'";
                return dialogue;
            }
            else
            {
                return stringToArray("The tombstone reads: 'Here Lies Robert, Awaiting The Day He Might Meet Matilda Again Under The Tree Where They First Met'");
            }
        }
        //If interacting with grave before obtaining the letter
        else
        {
            return stringToArray("You look at the grave. It's old and weathered, and the words etched into the stone are worn and faded. You don't even bother trying to make out what they say.");
        }
    }
}
