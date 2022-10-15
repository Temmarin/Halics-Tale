using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueWithKey : Statue
{
    private int updateKeyIndex = 1;
    private bool interacted = false;

    public override string[] getMessage()
    {
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            //If interacting with the statue after receiving the clue from the door
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                string[] dialogue = new string[3];
                dialogue[0] = "A beautiful statue looms over you. The stone is smooth from years of erosion. It depicts a lady praying. At the base of the statue, you notice an inscription...";
                dialogue[1] = "It depicts a series of unusual runes. You've studied their language, but the words don't make sense. It's as if some are... missing?";
                dialogue[2] = "As your eyes pass over the last rune, you notice a small, foreign gem on the ground. It glows strangely. You pick it up.";
                return dialogue;
            }
            else
            {
                string[] dialogue = new string[2];
                dialogue[0] = "A beautiful statue looms over you. The stone is smooth from years of erosion. It depicts a lady praying. At the base of the statue, you notice an inscription...";
                dialogue[1] = "It depicts a series of unusual runes. You've studied their language, but the words don't make sense. It's as if some are... missing?";
                return dialogue;
            }
            
        }
        else
        {
            //If interacting with the statue before receiving the clue from the door
            return stringToArray("A beautiful statue looms over you. The stone is smooth from years of erosion. It depicts a lady praying. You don't notice anything notable, however.");
        }
    }
}
