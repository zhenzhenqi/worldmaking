using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class SchoolSceneDirector : MonoBehaviour
{
    public SchoolKidController kid;
    public SchoolTeacherController teacher;
    public Animator scene_transition_animator;

    bool seqPlayed;

    public CameraControl cameraControl;


    public GameCreator.Dialogue.Dialogue dialogue1, dialogue2;

    //public bool dialogue1Ended, dialogue2Ended, teacherGone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //For dialogues to call
    public void D1Ended()
    {
        StartCoroutine(SlappingSeq());
    }

    public void D2Ended()
    {
        StartCoroutine(TeacherWalkSeq());
    }
    //.....end
    



    void StartInitDialogue()
    {
        cameraControl.focusOnEvent = true;
        PlayerKid.main.isLocked = true;
        dialogue1.RunDialogue();
        teacher.status = SchoolTeacherController.Status.Scolding;
    }

     IEnumerator SlappingSeq()
    {
        teacher.status = SchoolTeacherController.Status.Standing;
        yield return new WaitForSeconds(1);
        kid.status = SchoolKidController.Status.Slapping;
        yield return new WaitForSeconds(2);
        dialogue2.RunDialogue();        
    }

    IEnumerator TeacherWalkSeq()
    {
      
        kid.status = SchoolKidController.Status.StandFaceOut;
        yield return new WaitForSeconds(2);
        StartCoroutine(teacher.StartWalkAway());
      
        while (!teacher.gone)
        {
            yield return new WaitForEndOfFrame();
        }

        //teacher gone !
        PlayerKid.main.isLocked = false;
        cameraControl.focusOnEvent = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {

            if (seqPlayed) return;
            StartInitDialogue();
            seqPlayed = true;
            
        }
    }

    IEnumerator FadeToSceneMap()
    {
        scene_transition_animator.SetBool("isFadeOut", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Big_Map_Navigation", LoadSceneMode.Single);
    }

    public void loadSceneMap()
    {
        StartCoroutine(FadeToSceneMap());
    }

}
