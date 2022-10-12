using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class pc : MonoBehaviour
{
    [SerializeField] private float forceMult;
    //[SerializeField] private Rigidbody2D pcRb2d;
    [SerializeField] private SpriteRenderer pcSr;
    [SerializeField] private SpriteRenderer shadowSr;
    [SerializeField] private Tilemap walkable;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        }
        //animator.SetFloat("pcSpeed", Mathf.Abs(init - transform.position.magnitude));
    }
}
