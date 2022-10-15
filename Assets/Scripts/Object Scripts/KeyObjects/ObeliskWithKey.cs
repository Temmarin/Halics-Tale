using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskWithKey : Obelisk
{
    private int updateKeyIndex = 2;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            //If interacting with the obelisk after having found the gem by the statue
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                string[] dialogue = new string[4];
                dialogue[0] = "An ancient obelisk stands before you, engraved with delicate runes. The runes, you realize, are of the same kind as the statue you observed earlier.";
                dialogue[1] = "As you read through the runes, you realize they precisely match those you saw at the base of the statue. At the base of the obelisk, you notice a small, round indentation.";
                dialogue[2] = "Following your instincts, you slip the strange gem into the depression. Magic whirs around you, and the runes begin to shift. After they settle, you realize they're now legible.";
                dialogue[3] = "'The Eastern Gods Sit Upon Mighty Thrones'";
                return dialogue;
            }
            else
            {
                return stringToArray("'The Eastern Gods Sit Upon Mighty Thrones'");
            }
            
        }
        else
        {
            //If interacting with the obelisk before having found the gem by the statue
            return stringToArray("An ancient obelisk stands before you, engraved with delicate runes. It's old, and you wonder what kind of dormant power may lie sleeping within.");
        }
    }
}
