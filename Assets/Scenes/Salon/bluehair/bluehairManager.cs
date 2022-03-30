using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluehairManager : MonoBehaviour
{
    public SalonSceneManager sceneManager;
    public bool playerWithinRange;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerWithinRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneManager.isInConvo)
        {
            animator.SetBool("isTalking", true);
        }
        else
        {
            animator.SetBool("isTalking", false);
        }
    }

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
