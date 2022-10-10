using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pc : MonoBehaviour
{
    [SerializeField] private float forceMult;
    //[SerializeField] private Rigidbody2D pcRb2d;
    [SerializeField] private SpriteRenderer pcSr;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Move left by adding force
            //pcRb2d.AddForce(transform.right * Time.deltaTime * -forceMult);
            transform.position += new Vector3(-1f, 0f, 0f) * (forceMult * Time.deltaTime);
            //Flip sprite
            pcSr.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Move right by adding force
            //pcRb2d.AddForce(transform.right * Time.deltaTime * forceMult);
            transform.position += new Vector3(1f, 0f, 0f) * (forceMult * Time.deltaTime);
            //Flip sprite
            pcSr.flipX = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //Move up by adding force
            transform.position += new Vector3(0f, 1f, 0f) * (forceMult * Time.deltaTime);
            //pcRb2d.AddForce(transform.up * Time.deltaTime * forceMult);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -1f, 0f) * (forceMult * Time.deltaTime);
            //Move down by adding force
            //pcRb2d.AddForce(transform.up * Time.deltaTime * -forceMult);
        }
    }
}
