using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float moveSpeed;
    public bool goingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = 0.4f;
        goingRight = Random.value >= 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
    }

    void Fall()
    {
        float rightMovement = goingRight ? 0.08f : -0.08f;

        if ( Random.value > 0.99)
        {
            goingRight = !goingRight;
        }

        rigidBody.velocity = new Vector2(rightMovement, -moveSpeed);
        if (gameObject.transform.position.y < -1)
        {
            //Destroy(this.gameObject);
        }
    }
}
