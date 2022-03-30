using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaffManager : MonoBehaviour
{
    public StationSceneManager sceneManager;
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

    }
    public void StartTalk()
    {
        StartCoroutine(PlayNodAnimation());
    }
    public void EndTalk()
    {
        StopCoroutine(PlayNodAnimation());
    }

    IEnumerator PlayNodAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));

            for (int i = 0; i < 2; i++)
            {
                animator.SetTrigger("nod");
                yield return new WaitForSeconds(0.2f);
            }
        }

    }

    public void OnDisable()
    {
        StopCoroutine(PlayNodAnimation());
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
