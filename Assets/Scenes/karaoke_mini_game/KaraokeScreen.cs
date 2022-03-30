using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaraokeScreen : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            animator.SetBool("isStarted", true);
        }
    }
}
