using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChest : Object
{
    private int keyIndex = 6;
    private int updateKeyIndex = 7;
    private bool interacted = false;
    
    public override string[] getMessage()
    {
        //If interacting with the chest after obtaining the first key
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                return stringToArray("You try the key you have with the lock on the chest. It slides in, and with a click, the chest opens. Inside you find a crowbar.How peculiar...");
            }
            else
            {
                return stringToArray("You've already taken out the crowbar. There's nothing left here anymore besides an empty chest.");
            }
        }
        //If interacting with the chest before obtaining the first key
        else
        {
            return stringToArray("There's a chest here. As expected, it's locked, and you don't have the key.");
        }
    }
}
