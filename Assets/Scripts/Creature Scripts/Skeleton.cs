using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Creature
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer skeletonSR;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(skeletonMovement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator skeletonMovement()
    {
        Debug.Log("Started!");
        while (true)
        {
            Debug.Log("Distance Is: " + Vector2.Distance(gameObject.transform.position, pc.Instance.transform.position));
            if (Vector2.Distance(gameObject.transform.position, pc.Instance.transform.position) < 5f)
            {
                while (Vector2.Distance(gameObject.transform.position, pc.Instance.transform.position) > 1f)
                {
                    animator.SetFloat("skeletonSpeed", 1f);
                    gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, pc.Instance.transform.position, (speed * Time.deltaTime));
                    if (gameObject.transform.position.x < pc.Instance.transform.position.x)
                    {
                        skeletonSR.flipX = true;
                    }
                    else if (gameObject.transform.position.x > pc.Instance.transform.position.x)
                    {
                        skeletonSR.flipX = false;
                    }
                    yield return null;
                }
                animator.SetFloat("skeletonSpeed", 0f);
                yield return null;
            }
            yield return null;
        }
    }
    
    public override string[] getMessage()
    {
        string[] lines = new string[13];
        lines[0] = "As you enter the crypt, you're shocked to see a skeleton standing before you. He looks at you.";
        lines[1] = "'Looks like someone figured it out. Finally. Took you long enough.'";
        lines[2] = "You're at a loss for words. What on earth is going on?";
        lines[3] = "The skeleton sighs. 'Alright, you look confused. Hi, I'm Halic. I'm pretty dead, as you can clearly see with your very alive eyes.'";
        lines[4] = "'I was buried here, but the bastard that killed me cursed my soul to remain bound to this earth, blah blah blah.'";
        lines[5] = "'Anyway, the gods don't even know how long I've been in here but I'm ready to be released from this damn curse.'";
        lines[6] = "'Over the years I taught myself magic so I could get someone's - ANYONE'S - attention.'";
        lines[7] = "'In short, now that you're here and, based on those clothes, you're very much a magic user yourself, break my curse, please and thank you.'";
        lines[8] = "You continue to stare at him, still not really sure what to say.";
        lines[9] = "'Well? Come on. I'm waiting you know. Just do it already. I know you can, and you have no reason not to.'";
        lines[10] =
            "You decide you don't have to say anything. He's right: you might as well. You raise your staff and concentrate on his aura to find the energy perpetuating the curse.";
        lines[11] = "You pinpoint it, chant a spell, and cast it from his body.";
        lines[12] =
            "As magic electrifies the air, you hear an audible sigh, one that seems to be of relief from him, as he crumbles to the ground. Looks like that's that.";
        StartCoroutine(deathAnimation());
        gameObject.layer = 0;
        return lines;
    }

    IEnumerator deathAnimation()
    {
        int clickCount = 0;
        while (clickCount != 11)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                clickCount++;
            }
            yield return null;
        }
        animator.Play("skeleton_death");
        yield return new WaitForSeconds(1f);
        animator.enabled = false;
        yield return null;
    }
}
