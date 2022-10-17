using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelWithKey : Barrel
{
    private int updateKeyIndex = 8;
    
    public override string[] getMessage()
    {
        //If interacting with the barrel after acquiring the crowbar
        if (KeyIndex.Instance.checkKey(keyIndex))
        {
            if (!interacted)
            {
                KeyIndex.Instance.updateKey(updateKeyIndex);
                interacted = true;
                string[] dialogue = new string[3];
                dialogue[0] = "You pry off the barrel's lid with the rusty crowbar you found. Inside, you find a strange letter...";
                dialogue[1] = "To My Dearest Robert,\n Distance is nothing compared to this. Every day I yearn for you, only to remember you're gone.";
                dialogue[2] = "Until the day I pass, and I might see you again on the other side, please... wait for me. \n Your Dearest, \n Matilda";
                return dialogue;
            }
            else
            {
                string[] dialogue = new string[3];
                dialogue[0] = "You've already removed the letter from the barrel. You decide to read it over again...";
                dialogue[1] = "To My Dearest Robert,\n Distance is nothing compared to this. Every day I yearn for you, only to remember you're gone.";
                dialogue[2] = "Until the day I pass, and I might see you again on the other side, please... wait for me. \n Your Dearest, \n Matilda";
                return dialogue;
            }
        }
        //If interacting with the barrel before acquiring the crowbar
        else
        {
            return stringToArray("You inspect the barrel. It's old and weathered, but the lid is still shut tight. Maybe if you had a crowbar or something you could open it...");
        }
    }
}
