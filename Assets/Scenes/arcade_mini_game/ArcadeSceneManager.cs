using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ArcadeSceneManager : MonoBehaviour
{
    public static string PreviousLevel;
    // Start is called before the first frame update
    void Start()
    {
        if(PreviousLevel != "")
        {
            Debug.Log(PreviousLevel);
        }

        if(PreviousLevel == "arcade_mini_game" && gameObject.scene.name == "arcade")
        {
            Debug.Log("need change position");
            ChangePlayerStartPosition();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnDestroy()
    {
        PreviousLevel = gameObject.scene.name;

    }


    private void ChangePlayerStartPosition()
    {
        FirstPersonMovement player = FindObjectOfType<FirstPersonMovement>();
        player.transform.position = new Vector3(-0.5f, -0.94f, 0.055f);
        player.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);


    }


}
