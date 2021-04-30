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

        // EXAMPLE A: initialize with the preferences set in DOTween's Utility Panel
        DOTween.Init();
        // EXAMPLE B: initialize with custom settings, and set capacities immediately
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);

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
            // //this.gameObject.transform.DOScale(this.gameObject.transform.localScale * 10/100, 0.2f);
            //var sequence = this.gameObject.transform.DOScale(0, 2f);

            sequence = DOTween.Sequence()
            .Append(this.gameObject.transform.DOScale(this.gameObject.transform.localScale * 10 / 100, 0.5f))
            .Append(this.gameObject.transform.DOScale(0, 1f));
            //DOTween.=.Play(sequence);
            //this.gameObject.GetComponent<Animator>().SetBool("isTooLow", true);
        }


        if (gameObject.transform.position.y < -1) //END OF SCREEN
        {
            KillTween();
            Destroy(this.gameObject);
        }
    }

    public void KillTween()
    {
        DOTween.Kill(this.gameObject);
        sequence.Kill();
        myTween.Kill();
    }
}
