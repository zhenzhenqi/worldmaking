using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDot : MonoBehaviour
{


    public bool isLocked = false;
    public float speed = 0.1f;
    Rigidbody2D rb2d;


    SpriteRenderer spriteRenderer;
    public string standingLookingRightState = "look_right", standingLookingUpState = "look_up", standingLookingDownState = "look_down", walkState = "walk";

    public enum Facing { left, right, up, down };
    Facing facing;
    bool walking;


    public class NavigationConstrain
    {
        public bool canGoRight = true, canGoLeft = true, canGoUp = true, canGoDown = true;
    }

    public NavigationConstrain navigationConstrain = new NavigationConstrain();





    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        var hor = Input.GetAxis("Horizontal") * speed;
        var veri = Input.GetAxis("Vertical") * speed;

        if (hor > 0 && !navigationConstrain.canGoRight) return;
        if (hor < 0 && !navigationConstrain.canGoLeft) return;
        if (veri > 0 && !navigationConstrain.canGoUp) return;
        if (veri < 0 && !navigationConstrain.canGoDown) return;

        //remeber facing
        if (hor > 0)
        {
            facing = Facing.right;
            walking = true;
        }
        else if (hor < 0)
        {
            facing = Facing.left;
            walking = true;
        }
        else if (veri > 0)
        {
            walking = false;
            facing = Facing.up;
        }
        else if (veri < 0)
        {
            walking = false;
            facing = Facing.down;
        }
        else
        {
            walking = false;
        }


        if (facing == Facing.left)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }


        if (isLocked) walking = false;
        //walk    




        if (!isLocked)
            rb2d.MovePosition(rb2d.position + new Vector2(hor, veri));

    }
}
