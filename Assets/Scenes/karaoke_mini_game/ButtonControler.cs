using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite defualtImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            spriteRenderer.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            spriteRenderer.sprite = defualtImage;

        }
    }
}
