using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int maximumXPosition;
    public int minimumXPosition;
    public float xForce;
    public float yForce;
    public float xDirection;
    private Rigidbody2D enemyRigidbody;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidbody.AddForce(jumpForce);
        }

        if(collision.gameObject.tag == "ThrowingObject")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= minimumXPosition)
        {
            xDirection = 1;
            enemyRigidbody.AddForce(Vector2.right * xForce);
        }

        if(transform.position.x >= maximumXPosition)
        {
            xDirection = -1;
            enemyRigidbody.AddForce(Vector2.left * xForce);
        }
    }
}
