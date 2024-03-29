using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Object : MonoBehaviour, IInteract
{
    public void interact ()
    {
        Dialogue dialogue = new Dialogue(getMessage());
        DialogueManager.Instance.StartDialogue(dialogue);
        return;
    }

    public virtual string[] getMessage()
    {
        string message = "You're... not quite sure what this is? It's definitely an object, though.";
        return stringToArray(message);
    }

    public string[] stringToArray(string sentence)
    {
        var message = new string[1];
        message[0] = sentence;
        return message;
    }
}
