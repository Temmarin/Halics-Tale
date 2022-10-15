using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWithKey : Tree
{
    private int keyIndex = 9;
    private int updateKeyIndex = 10;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with tree after reading message on robert's grave
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                return stringToArray("A beautiful, tall tree looms before you. As you admire it's beauty, a flash of silver catches your eye. You notice a key lodged in a hollow in the bark.");
            }
            else
            {
                return stringToArray("You've already taken the key out of the hollow in the bark. You wonder if this is the tree where Robert and Matilda first met... it's rather pretty.");
            }
            
        }
        //If interacting with tree before reading message on robert's grave
        else
        {
            return stringToArray("A tall, lush tree looms before you. It's just a tree, but you can't help admiring it's beauty for a little while.");
        }
    }
}
