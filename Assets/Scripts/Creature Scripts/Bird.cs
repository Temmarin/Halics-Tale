using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Creature
{
    private int keyIndex = 4;
    private int updateKeyIndex = 5;
    
    public override string[] getMessage()
    {
        //If interacting with a bird after obtaining berries
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            KeyIndex.Instance.updateKey(updateKeyIndex);
            return stringToArray("You offer berries to the bird. It eats them up greedily, and then loudly squawks at you 'secret shiny big rock BIG ROCK' before flying away.");
        }
        //If interacting with a bird before obtaining berries
        else
        {
            return stringToArray("The bird squawks, cocks it's head, and then proceeds to ignore you. Guess you don't have what it wants.");
        }
    }
}
