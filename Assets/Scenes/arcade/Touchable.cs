using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touchable : MonoBehaviour
{
    FirstPersonMovement player;
    bool isPlayerFound;

    Animator animator;

    bool isTouchable;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        //screenMaterial = this.GetComponent<Renderer>().material;
        //originalColor = screenMaterial.color;


        player = FindObjectOfType<FirstPersonMovement>();
        
        isTouchable = false;
        if (player)
        {
            Debug.LogWarning("find player:" + player.name);
            isPlayerFound = true;
            
        }
        else
        {
            Debug.LogWarning("no Player found");
            isPlayerFound = false;
        }

        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchable && Input.GetKeyDown("space"))
        {
            Debug.LogWarning("Screen Touched");
            SceneManager.LoadScene("arcade_mini_game");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isPlayerFound && other.gameObject.name == player.name)
        {
            Debug.LogWarning("Player Entered");
            //screenMaterial.color = new Vector4(1f, 0.2f, 0.2f, 1f);

            if (animator)
            {
                animator.SetBool("isEntered", true);
            }
            

            if (audiosource)
            {
                audiosource.Play();
            }

            isTouchable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPlayerFound && other.gameObject.name == player.name)
        {
            if (animator)
            {
                animator.SetBool("isEntered", false);
            }

            Debug.LogWarning("Player Exit");
            //screenMaterial.color = originalColor;

            isTouchable = false;
        }
    }
}
