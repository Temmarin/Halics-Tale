using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, IInteract
{
    public void interact ()
    {
        Dialogue dialogue = new Dialogue(getMessage());
        DialogueManager.Instance.StartDialogue(dialogue);
        return;
    }

    public virtual string[] getMessage()
    {
        string message = "That's a creature of some kind, alright.";
        return stringToArray(message);
    }

    public string[] stringToArray(string sentence)
    {
        var message = new string[1];
        message[0] = sentence;
        return message;
    }
}
