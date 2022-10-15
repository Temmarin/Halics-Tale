using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellWithKey : Well
{
    private int updateKeyIndex = 13;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with well after acquiring treasure map
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                return stringToArray("You dig up the ground in the center of the well. You hear the gentle clang of your shovel hitting something metal. You reach into the hole and pull out a beautiful, ornate key.");
            }
            else
            {
                return stringToArray("You've already dug here. This key looks important, so it probably unlocks something important.");
            }
        }
        //If interacting with well before acquiring treasure map
        else
        {
            return stringToArray("You look at the old, destroyed well. It must've been filled long, long ago.");
        }
    }
}
