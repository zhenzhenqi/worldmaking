using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldmancontroller : MonoBehaviour
{


    public FaceSceneManager sceneManager;
    public GameCreator.Dialogue.Dialogue myDialogue;
    public SchoolKidController kid;
    SpriteRenderer renderer;
    public bool playerWithinRange;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(OldManNod());
    }

    // public IEnumerator StartDialogue()
    // {       
    //    yield return myDialogue.Run();    
    // }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OldManNod()
    {
        while (true)
        {
            if (sceneManager.isInConvo)
            {
                for (int i = 0; i < 2; i++)
                {
                    animator.SetTrigger("nod");
                    yield return new WaitForSeconds(0.3f);
                }

                yield return new WaitForSeconds(Random.Range(3, 6));
            }
            yield return new WaitForEndOfFrame();
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.gameObject.tag == "Player")
    //     {
    //         Debug.Log("player in range");
    //         animator.SetBool("isTalking", true);
    //         myDialogue.RunDialogue();
    //         PlayerKid.main.isLocked = true;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         Debug.Log("player out of range");
    //         animator.SetBool("isTalking", false);
    //     }
    // }


    public void endDialogue()
    {
        PlayerKid.main.isLocked = false;
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
