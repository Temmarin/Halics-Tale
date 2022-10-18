using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    private string[] lines = new string[8];
    // Start is called before the first frame update
    void Start()
    {
        lines[0] = "Use your left mouse button to click through on-screen dialogue.";
        lines[1] = "You look around... looks like you've made it to the right place. As you inspect your surroundings, you feel a buzzing pulse in your head.";
        lines[2] = "Must be from the enclave of mages. You tap into the signal...";
        lines[3] = "'Amadia, seems like you've made it in one piece. Glad the teleportation went safely.'";
        lines[4] = "'As we discussed earlier, the magical disturbance in this area hasn't yet let up. See if you can figure out what's going on. Good luck.'";
        lines[5] = "The connection breaks, and you're back on your own once again. From your knowledge, the area the disturbance is coming from is right past this door.";
        lines[6] = "You figure it's probably best to start there.";
        lines[7] = "Use WASD to move and E to interact with your surroundings.";
        StartCoroutine(waiting());
        return;
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(.5f);
        Dialogue dialogue = new Dialogue(lines);
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
