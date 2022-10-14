using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Object : MonoBehaviour, IInteract
{
    private int numKey = 10;
    protected bool[] Keys = new bool[10];
    
    // Start is called before the first frame update
    public void interact ()
    {
        //string[] sentencesToPass = {getMessage()};
        //dialogue.sentences = sentencesToPass;
        //Dialogue dialogue;
        Dialogue dialogue = new Dialogue(getMessage());
        DialogueManager.Instance.StartDialogue(dialogue);
        return;
    }

    public virtual string getMessage()
    {
        return "You're... not quite sure what this is? It's definitely an object, though.";
    }

    protected bool checkKey(int index)
    {
        if (index < numKey)
        {
            return Keys[index];
        }
        return false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
