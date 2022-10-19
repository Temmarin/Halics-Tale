using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class pc : MonoBehaviour
{
    public static pc Instance;
    
    [SerializeField] private float forceMult;
    [SerializeField] private SpriteRenderer pcSr;
    [SerializeField] private SpriteRenderer shadowSr;
    [SerializeField] private Tilemap walkable;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask objectCheck;
    [SerializeField] private AudioSource audioSourceMovement;
    [SerializeField] private AudioSource audioSourceInteract;
    [SerializeField] private GameObject teleportPad;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            audioSourceMovement.mute = false;
        }
        //var init = transform.position.magnitude;
        //animator.SetFloat("pcSpeed", transform.position.magnitude);
        //animator.SetFloat("pcSpeed", rb2d.velocity.magnitude);
        if (Input.GetKey(KeyCode.A))
        {
            //Move left by adding force
            //pcRb2d.AddForce(transform.right * Time.deltaTime * -forceMult);
            transform.position += new Vector3(-1f, 0f, 0f) * (forceMult * Time.deltaTime);
            //Flip sprite
            pcSr.flipX = true;
            shadowSr.flipX = false;
            animator.SetFloat("pcSpeed", 1f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            //Move right by adding force
            //pcRb2d.AddForce(transform.right * Time.deltaTime * forceMult);
            transform.position += new Vector3(1f, 0f, 0f) * (forceMult * Time.deltaTime);
            //Flip sprite
            pcSr.flipX = false;
            shadowSr.flipX = true;
            animator.SetFloat("pcSpeed", 1f);

        }
        if (Input.GetKey(KeyCode.W))
        {
            //Move up by adding force
            transform.position += new Vector3(0f, 1f, 0f) * (forceMult * Time.deltaTime);
            //pcRb2d.AddForce(transform.up * Time.deltaTime * forceMult);
            animator.SetFloat("pcSpeed", 1f);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -1f, 0f) * (forceMult * Time.deltaTime);
            //Move down by adding force
            //pcRb2d.AddForce(transform.up * Time.deltaTime * -forceMult);
            animator.SetFloat("pcSpeed", 1f);

        }
        if (!Input.anyKey)
        {
            animator.SetFloat("pcSpeed", 0f);
            audioSourceMovement.mute = true;

        }
        //animator.SetFloat("pcSpeed", Mathf.Abs(init - transform.position.magnitude));
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSourceInteract.Play();
            var collision = Physics2D.OverlapCircle(transform.position, radius, objectCheck);
            if (collision != null)
            {
                IInteract interactible = collision.gameObject.GetComponent<IInteract>();
                if (interactible != null) //If object is interactible...
                {
                    interactible.interact();
                }
                else
                {
                    Dialogue dialogue =
                        new Dialogue("Hmm... It doesn't look like there's anything to interact with around here...");
                    DialogueManager.Instance.StartDialogue(dialogue);
                }
            }
            else
            {
                Dialogue dialogue =
                    new Dialogue("Hmm... It doesn't look like there's anything to interact with around here...");
                DialogueManager.Instance.StartDialogue(dialogue);
            }
        }
    }

    public void teleportPlayer()
    {
        StartCoroutine(initiateTeleport());
    }

    IEnumerator initiateTeleport()
    {
        while (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            yield return null;
        }
        //Fade Camera here?
        gameObject.transform.position = teleportPad.transform.position;
        yield return null;
    }
}
