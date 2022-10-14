using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Dialogue(string sentence)
    {
        sentences = new string[1];
        sentences[0] = sentence;
    }
    public string[] sentences;
    
}
