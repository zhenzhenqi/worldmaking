using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 eventCam;
    public bool focusOnEvent;

    Vector3 vel;
    Vector3 targetPos;
    public SpriteRenderer backgroundSprite;


    float leftMostPos;
    float rightMostPos;
    float topMostPos;
    float bottomMostPos;

    Vector2 cameraSpectrumPixelSize;
    float z;


    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player").transform;
        //UpdateMyX(leftEndX);

        cameraSpectrumPixelSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize * 2f, Camera.main.orthographicSize * 2f);

        var bounds = backgroundSprite.bounds;
        float leftEdgeWorldPos = bounds.center.x - bounds.extents.x;
        float rightEdgeWorldPos = bounds.center.x + bounds.extents.x;
        float topEdgeWorldPos = bounds.center.y + bounds.extents.y;
        float bottomEdgeWorldPos = bounds.center.y - bounds.extents.y;
        leftMostPos = leftEdgeWorldPos + cameraSpectrumPixelSize.x / 2f;
        rightMostPos = rightEdgeWorldPos - cameraSpectrumPixelSize.x / 2f;
        topMostPos = topEdgeWorldPos - cameraSpectrumPixelSize.y / 2f;
        bottomMostPos = bottomEdgeWorldPos + cameraSpectrumPixelSize.y / 2f;


        z = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (focusOnEvent)
        {
            targetPos = eventCam;
        }
        else
        {
            var p = player.position;

            if (p.x < leftMostPos) { p.x = leftMostPos; }
            if (p.x > rightMostPos) { p.x = rightMostPos; }
            if (p.y < bottomMostPos) { p.y = bottomMostPos; }
            if (p.y > topMostPos) { p.y = topMostPos; }
            targetPos = p;
        }
      

      
        targetPos.z = z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, 0.4f);


    }

}
