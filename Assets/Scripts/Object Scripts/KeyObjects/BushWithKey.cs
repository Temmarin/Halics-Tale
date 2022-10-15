using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushWithKey : Bush
{
    private int keyIndex = 3;
    private int updateKeyIndex = 4;
    
    public override string[] getMessage()
    {
        //If interacting with the bush after obtaining the clue from the obelisk
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            KeyIndex.Instance.updateKey(updateKeyIndex);
            return stringToArray("A berry bush. The berries are ripe, too. You pick some.");
        }
        //If interacting with the bush before obtaining the clue from the obelisk
        else
        {
            return stringToArray("A berry bush. Nothing out of the ordinary here.");
        }
    }
}
