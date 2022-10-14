using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelWithKey : Barrel
{
    private int updateKeyIndex = 0;
    
    public override string getMessage()
    {
        if (!checkKey(keyIndex))
        {
            return
                "You inspect the barrel. It's old and weathered, but the lid is still shut tight. Maybe if you had a crowbar or something...";
        }

        if (checkKey(keyIndex))
        {
            Keys[updateKeyIndex] = true;
            return
                "You pry open the barrel's lid with the rusty crowbar you found. [YOU FIND SOMETHIN].";
        }

        return "There must be an error here!";
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
