using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Object
{
    private int updateKeyIndex = 0;
    private int keyIndex1 = 0;
    private int keyIndex2 = 0;
    private int keyIndex3 = 0;
    
    public override string getMessage()
    {
        if (checkKey(keyIndex1) || checkKey(keyIndex2))
        {
            return
                "[Key does not go to the door]";
        }
        else if (checkKey(keyIndex3))
        {
            return
                "[Key unlocks door]";
        }
        else
        {
            return "Beginning statement";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
