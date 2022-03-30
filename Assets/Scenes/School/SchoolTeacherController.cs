
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolTeacherController : MonoBehaviour
{
    public enum Status
    {
        Standing,Scolding,Walking
    }


    public bool gone;

    public Status status;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        animator.SetInteger("status", (int)status);
    }



    public IEnumerator StartWalkAway()
    {
        status = Status.Walking;
        while(transform.position.x < 1.3f)
        {
            transform.Translate(0.05f, 0, 0);
            yield return new WaitForSeconds(0.5f);
        }
        gone = true;
    }







}
