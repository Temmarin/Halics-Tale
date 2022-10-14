using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Object
{
    protected int keyIndex = 0;
    
    public override string getMessage()
    {
        if (!checkKey(keyIndex))
        {
            return
                "You inspect the barrel. It's old and weathered, but the lid is still shut tight. Maybe if you had a crowbar or something...";
        }

        if (checkKey(keyIndex))
        {
            return
                "You pry open the barrel's lid with the rusty crowbar you found. Unfortunately, there's nothing but dust and rotting wood inside.";
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
