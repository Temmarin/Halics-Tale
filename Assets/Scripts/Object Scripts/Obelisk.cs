using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : Object
{
    protected int keyIndex = 1;

    public override string[] getMessage()
    {
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            //If interacting with the obelisk after having found the gem by the statue
            string[] dialogue = new string[2];
            dialogue[0] = "An ancient obelisk stands before you, engraved with delicate runes. The runes, you realize, are of the same kind as the statue you observed earlier.";
            dialogue[1] = "Upon further inspection, it doesn't appear as though the statue and this obelisk are connected in any particular way. Maybe the others are, though?";
            return dialogue;
        }
        else
        {
            //If interacting with the obelisk before having found the gem by the statue
            return stringToArray("An ancient obelisk stands before you, engraved with delicate runes. It's old, and you wonder what kind of dormant power may lie sleeping within.");
        }
    }
}
