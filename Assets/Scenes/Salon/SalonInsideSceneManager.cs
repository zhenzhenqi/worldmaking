using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameCreator.Dialogue;

public class SalonInsideSceneManager : MonoBehaviour
{
    public Dialogue Dialogue_bluehair;
    public Animator animator;
    private bool isInConvo;
    // Start is called before the first frame update
    void Start()
    {
        isInConvo = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isInConvo == false)
        {
            StartCoroutine(StartDialogue());
        }
    }

    IEnumerator StartDialogue()
    {
        isInConvo = true;
        yield return Dialogue_bluehair.Run();
        yield return new WaitForSeconds(3);
        Debug.Log("ready to switch to next scene");
    }

    IEnumerator FadeToSceneMap()
    {
        animator.SetBool("isFadeOut", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Big_Map_Navigation", LoadSceneMode.Single);
    }

    public void loadSceneMap()
    {
        StartCoroutine(FadeToSceneMap());
    }
}
