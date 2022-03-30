using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKid : MonoBehaviour
{

    public enum Facing { left, right, up, down };
    Facing defaultFacing = Facing.right;
    public static PlayerKid main = null;
    public bool isLocked = false;
    public float speed = 0.1f;
    Rigidbody2D rb2d;
    Animator animator;
    SpriteRenderer spriteRenderer;

    Facing lastFacing;
    float v, h;
    float maxV = 1, minV = -1, maxH = 1, minH = -1;

    public class NavigationConstrain
    {
        public bool canGoRight = true, canGoLeft = true, canGoUp = true, canGoDown = true;
    }

    public NavigationConstrain navigationConstrain = new NavigationConstrain();

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Debug.LogError("more than 1 player!!!");
            Application.Quit();
        }
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lastFacing = defaultFacing;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        maxH = navigationConstrain.canGoRight ? 1 : 0;
        minH = navigationConstrain.canGoLeft ? -1 : 0;
        maxV = navigationConstrain.canGoUp ? 1 : 0;
        minV = navigationConstrain.canGoDown ? -1 : 0;

        horizontal = Mathf.Clamp(horizontal, minH, maxH);
        vertical = Mathf.Clamp(vertical, minV, maxV);

        if (horizontal > 0) { lastFacing = Facing.right; }
        else if (horizontal < 0) { lastFacing = Facing.left; }
        else if (vertical > 0) { lastFacing = Facing.up; }
        else if (vertical < 0) { lastFacing = Facing.down; }


        spriteRenderer.flipX = lastFacing == Facing.left;

        h = horizontal;
        v = vertical;

        switch (lastFacing)
        {
            case Facing.left:
                if (h > -0.2f) h = -0.2f;
                break;
            case Facing.right:
                if (h < 0.2f) h = 0.2f;
                break;
            case Facing.up:
                if (v < 0.2) v = 0.2f;
                break;
            case Facing.down:
                if (v > -0.2f) v = -0.2f;
                break;
        }


        if (!isLocked)
        {
            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                rb2d.MovePosition(rb2d.position + new Vector2(horizontal * Time.fixedDeltaTime * speed, 0));

            }
            else
            {
                rb2d.MovePosition(rb2d.position + new Vector2(0, vertical * Time.fixedDeltaTime * speed));
            }
        }

        animator.SetFloat("hor", h);
        animator.SetFloat("ver", v);
    }
}
