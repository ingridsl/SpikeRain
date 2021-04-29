using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float moveSpeed;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = 1f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        var isTouching = Input.touchCount > 0;
        animator.SetBool("moving", isTouching);
        if (isTouching)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Vector2 aux = (touch.position.x < Screen.width / 2) ?
                        new Vector2(-moveSpeed, 0) :
                        new Vector2(moveSpeed, 0);
                    rigidBody.velocity = aux;

                    break;
                case TouchPhase.Ended:
                    rigidBody.velocity = new Vector2(0, 0);
                    break;
            }
        }
    }
}