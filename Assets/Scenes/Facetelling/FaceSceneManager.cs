using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameCreator.Dialogue;

public class FaceSceneManager : MonoBehaviour
{
    public oldmancontroller oldman;
    public Dialogue myDialogue;
    public bool isInConvo;
    public Animator scene_transition_animator;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    //  public IEnumerator StartDialogue()
    // {       
    //    yield return myDialogue.Run();    
    // }

    // Update is called once per frame
    void Update()
    {
        if (oldman.playerWithinRange)
        {
           
            if (Input.GetKeyDown(KeyCode.Space) && isInConvo == false)
            {
                Debug.Log("dia started;");
                StartCoroutine(StartDialogue());
            }
        }
    }

     IEnumerator StartDialogue()
    {
        Debug.Log("entered coroutine.");
        isInConvo = true;
        PlayerKid.main.isLocked = true;
        yield return myDialogue.Run();
        isInConvo = false;
        PlayerKid.main.isLocked = false;
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
