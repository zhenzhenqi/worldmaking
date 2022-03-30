using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolKidController : MonoBehaviour
{
    Animator animator;
    public GameCreator.Dialogue.Dialogue myDialogue;
    bool playerWithinRange;
    bool isInConvo;
    SpriteRenderer renderer;



    public enum Status
    {
        StandFaceOut, Slapping, StandFaceRightSide, StandFaceLeftSide
    }

    public Status status;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
       
    }

    public void StartSlapping()
    {
        status = Status.Slapping;
    }
    public void StopSlapping()
    {
        status = Status.StandFaceOut;
    }


    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case Status.StandFaceOut:
                animator.SetInteger("status", 0);
                renderer.flipX = false;
                break;
            case Status.Slapping:
                animator.SetInteger("status", 1);
                renderer.flipX = false;
                break;
            case Status.StandFaceRightSide:
                animator.SetInteger("status", 2);

                break;
            case Status.StandFaceLeftSide:
                animator.SetInteger("status", 2);
                renderer.flipX = true;
                break;
        }

        if (playerWithinRange)
        {

            if (Input.GetKeyDown(KeyCode.Space) && isInConvo == false)
            {
                StartCoroutine(StartDialogue());
            }
        }
    }

    public IEnumerator StartDialogue()
    {
        isInConvo = true;
        PlayerKid.main.isLocked = true;
        status = Status.StandFaceLeftSide;
        yield return myDialogue.Run();
        isInConvo = false;
        PlayerKid.main.isLocked = false;
        status = Status.StandFaceOut;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerWithinRange = true;
            Debug.Log("player in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerWithinRange = false;
            Debug.Log("player out of range");
        }
    }

}
