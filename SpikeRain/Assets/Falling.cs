using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Falling : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float moveDownSpeed;
    public bool goingRight = false;

    private Sequence sequence;
    private Tween myTween;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveDownSpeed = 0.4f;
        goingRight = Random.value >= 0.5;

        var rot = new Vector3(0, 0, 360);
        myTween = DOTween.Sequence().
        Append(this.gameObject.transform.DORotate(rot, 5f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Restart));

    }

    // Update is called once per frame
    void Update()
    {
        Fall();
    }

    void Fall()
    {
        float rightMovement = goingRight ? 0.027f : -0.027f;

        if ( Random.value > 0.995)
        {
            goingRight = !goingRight;
        }

        rigidBody.velocity = new Vector2(rightMovement, -moveDownSpeed);
        
        if (gameObject.transform.position.y < -0.35) //LOWER THAN PLAYER
        {
            myTween.Kill();

            var localScale = this.gameObject.transform.localScale;
            sequence = DOTween.Sequence()
            .Append(this.gameObject.transform.DOScale(0, 1f));
        }


        if (gameObject.transform.position.y < -1 || this.gameObject.transform.localScale.x == 0) //END OF SCREEN
        {
            sequence.Kill();
            myTween.Kill();
            this.gameObject.transform.DOKill();

            DOTween.Validate();

            Destroy(this.gameObject);
        }
    }
    
}
