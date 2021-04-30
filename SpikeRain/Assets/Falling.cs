using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
    }

    void Fall()
    {
        rigidBody.velocity = new Vector2(0, -moveSpeed);
        if (gameObject.transform.position.y < -1)
        {
            Destroy(this.gameObject);
        }
    }
}
