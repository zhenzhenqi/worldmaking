using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchableKaraoke : MonoBehaviour
{
    FirstPersonMovement player;
    bool isPlayerFound;
    Material screenMaterial;
    Color originalColor;
    bool isTouchable;
    // Start is called before the first frame update
    void Start()
    {
        screenMaterial = this.GetComponent<Renderer>().material;
        originalColor = screenMaterial.color;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchable && Input.GetKeyDown("space"))
        {
            Debug.LogWarning("Screen Touched");
            SceneManager.LoadScene("karaoke_mini_game");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayerFound && other.gameObject.name == player.name)
        {
            Debug.LogWarning("Player Entered");
            screenMaterial.color = new Vector4(1f, 0.2f, 0.2f, 1f);

            isTouchable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPlayerFound && other.gameObject.name == player.name)
        {
            Debug.LogWarning("Player Exit");
            screenMaterial.color = originalColor;

            isTouchable = false;
        }
    }
}
