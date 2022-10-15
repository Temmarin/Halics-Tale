using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : Object
{
    protected int keyIndex = 0;

    public override string[] getMessage()
    {
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            //If interacting with the statue after receiving the clue from the door
            return stringToArray("A beautiful statue looms over you. The stone is smooth from years of erosion. It depicts a lady praying. You don't notice anything notable. Maybe there are more of these...");
        }
        else
        {
            //If interacting with the statue before receiving the clue from the door
            return stringToArray("A beautiful statue looms over you. The stone is smooth from years of erosion. It depicts a lady praying. You don't notice anything notable, however.");
        }
    }
}
