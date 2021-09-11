using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    Rigidbody2D rb;
    bool isGround = true;
    bool canControl = true;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!canControl)
            return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isGround = false;
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if(col.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");
            FindObjectOfType<ObstacleManager>().GameOver();
            GetComponent<Animator>().SetTrigger("die");
            canControl = false;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col);

        
    }
}
