using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Object
{
    private int updateKeyIndex1 = 0;
    private int updateKeyIndex2 = 14;
    private int keyIndex1 = 6;
    private int keyIndex2 = 10;
    private int keyIndex3 = 13;
    
    public override string[] getMessage()
    {
        KeyIndex.Instance.updateKey(updateKeyIndex1);
        if (KeyIndex.Instance.checkKey(keyIndex3))
        {
            //If you have the final key that unlocks the door
            KeyIndex.Instance.updateKey(updateKeyIndex2);
            pc.Instance.teleportPlayer();
            return stringToArray("The ornate key slides into the old lock, and, with a click, it opens. Eagerly, you head inside...");
        }
        else if (KeyIndex.Instance.checkKey(keyIndex1) || KeyIndex.Instance.checkKey(keyIndex2))
        {
            //If you have the first key that goes to the first chest, or the second key that unlocks the second chest
            return stringToArray("You try to stick the key in the door, but it doesn't fit... It must unlock something else.");
        }
        else
        {
            //If interacting with door before any keys are acquired
            return stringToArray("You try to push the door open, but it won't budge. Looks like it's locked. Written above the door, however, you notice the words, 'May the Lady watch over us all.'");
        }
    }
}
