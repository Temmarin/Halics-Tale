using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChest : Object
{
    private int keyIndex1 = 6;
    private int keyIndex2 = 10;
    private int updateKeyIndex = 11;
    private bool interacted = false;
    [SerializeField] private Sprite updateImage;
    
    public override string[] getMessage()
    {
        //If interacting with the chest after obtaining the second key
        if (KeyIndex.Instance.checkKey(keyIndex2))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = updateImage;
                return stringToArray("You try the newest key you have with the lock on the chest. It slides in, and with a click, the chest opens. Inside you find a shovel. Engraved on the handle are the words, 'Secrets Lie Buried In Ash'");
            }
            else
            {
                return stringToArray("You've already taken out the shovel with 'Secrets Lie Buried In Ash' engraved on the handle. There's nothing left here anymore besides an empty chest.");
            }
        }
        //If interacting with the chest after obtaining the first key
        else if (KeyIndex.Instance.checkKey(keyIndex1))
        {
            return stringToArray("You try to stick the key into the chest's lock, but it doesn't fit... It must unlock something else.");
        }
        //If interacting with the chest before obtaining either key
        else
        {
            return stringToArray("There's a chest here. As expected, it's locked, and you don't have the key.");
        }
    }
}
