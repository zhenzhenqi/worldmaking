using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameCreator.Dialogue;

public class SalonSceneManager : MonoBehaviour
{
    public bluehairManager bluehair;
    public blackhairManager blackhair;
    public Dialogue Dialogue_bluehair;
    public Dialogue Dialogue_blackhair;
    public Animator animator;

    public bool isInConvo;
    private bool talkedWithBlack;

    // Start is called before the first frame update
    void Start()
    {
        talkedWithBlack = false;
        isInConvo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (blackhair.playerWithinRange)
        {

            if (Input.GetKeyDown(KeyCode.Space) && isInConvo == false)
            {
                Debug.Log("dia started;");
                StartCoroutine(StartDialogueBlack());
            }
        }else if (bluehair.playerWithinRange && talkedWithBlack)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isInConvo == false)
            {
                Debug.Log("dia started;");
                StartCoroutine(StartDialogueBlue());
            }
        }

    }



    IEnumerator StartDialogueBlack()
    {
        Debug.Log("entered coroutine.");
        isInConvo = true;
        PlayerKid.main.isLocked = true;
        yield return Dialogue_blackhair.Run();
        talkedWithBlack = true;
        isInConvo = false;
        PlayerKid.main.isLocked = false;
    }

    IEnumerator StartDialogueBlue()
    {
        Debug.Log("entered coroutine.");
        isInConvo = true;
        PlayerKid.main.isLocked = true;
        yield return Dialogue_bluehair.Run();
        isInConvo = false;
        PlayerKid.main.isLocked = false;
    }

    IEnumerator FadeToSceneInside()
    {
        animator.SetBool("isFadeOut", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Inside", LoadSceneMode.Single);
    }

    public void loadScene_insideSalon()
    {
        StartCoroutine(FadeToSceneInside());
    }


}
