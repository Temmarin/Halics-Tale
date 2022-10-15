using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchWithKey : Bench
{
    private int keyIndex = 2;
    private int updateKeyIndex = 3;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with the bench after obtaining the clue from the obelisk
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                return stringToArray("Upon inspecting the bench closely, you notice a message etched roughly into the back of it: 'birds love berries and secrets'");
            }
            else
            {
                return stringToArray("The engraving reads: 'birds love berries and secrets'");
            }
        }
        //If interacting with the bench before obtaining the clue from the obelisk
        else
        {
            return stringToArray("There's a bench here. There's nothing much to it, besides the fact that it looks incredibly uncomfortable to sit on.");
        }
    }
}
