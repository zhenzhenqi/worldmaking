using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrereadColorFromMap : MonoBehaviour
{
    Texture2D mapTex;
    public SpriteRenderer mapRend;
    Color[] pixels;
    public Color pathColor;
    Transform player;


    public Transform testCube;

    public UnityEngine.UI.RawImage center, left, right, up, down;


    public bool demoMode;


    ///this one uses percentage, (0->1)
    Color GetPixelColor(Vector2 pos)
    {
        int realX = (int)(pos.x * mapTex.width);
        int realY = (int)(pos.y * mapTex.height);
        return pixels[realX + realY * mapTex.width];
    }

    bool IsWalkable(Color c)
    {
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        mapTex = mapRend.sprite.texture;
        pixels = mapTex.GetPixels();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {

        if (demoMode)
        {
            var ps = player.GetComponent<PlayerKid>();
            ps.navigationConstrain.canGoLeft = true;
            ps.navigationConstrain.canGoRight = true;
            ps.navigationConstrain.canGoUp = true;
            ps.navigationConstrain.canGoDown = true;
            return;
        }

        var centerPosWorld = player.transform.position - new Vector3(0, player.GetComponent<SpriteRenderer>().bounds.extents.y, 0);

        var rightSideWorld = centerPosWorld + Vector3.right * 0.01f;
        var leftSideWorld = centerPosWorld + Vector3.left * 0.01f;
        var upSideWorld = centerPosWorld + Vector3.up * 0.01f;
        var downSideWorld = centerPosWorld + Vector3.down * 0.01f;

        Vector2 leftPosMap = TranslateWorldPosToOnMap(leftSideWorld);
        Vector2 rightPosMap = TranslateWorldPosToOnMap(rightSideWorld);
        Vector2 upPosMap = TranslateWorldPosToOnMap(upSideWorld);
        Vector2 downPosMap = TranslateWorldPosToOnMap(downSideWorld);
        Vector2 centerPosMap = TranslateWorldPosToOnMap(centerPosWorld);


        Color leftColor = GetPixelColor(leftPosMap);
        Color upColor = GetPixelColor(upPosMap);
        Color downColor = GetPixelColor(downPosMap);
        Color rightColor = GetPixelColor(rightPosMap);
        Color centerColor = GetPixelColor(centerPosMap);


        //debug----------
        if (testCube != null) testCube.transform.position = centerPosWorld;
        center.color = centerColor;
        right.color = rightColor;
        left.color = leftColor;
        up.color = upColor;
        down.color = downColor;
        //debug  end ----------


        var playerScript = player.GetComponent<PlayerKid>();
        playerScript.navigationConstrain.canGoLeft = (leftColor.Brightness() > 0.5f);
        playerScript.navigationConstrain.canGoRight = (rightColor.Brightness() > 0.5f);
        playerScript.navigationConstrain.canGoUp = (upColor.Brightness() > 0.5f);
        playerScript.navigationConstrain.canGoDown = (downColor.Brightness() > 0.5f);




    }


    void SnapPlayerToNearestWalkable()
    {

    }

    Vector2 TranslateWorldPosToOnMap(Vector3 worldPos)
    {

        var bounds = mapRend.bounds;
        float leftEdgeWorldPos = bounds.center.x - bounds.extents.x;
        float bottomEdgeWorldPos = bounds.center.y - bounds.extents.y;



        return new Vector2
         (
             ((worldPos.x + leftEdgeWorldPos) / bounds.size.x) + 1,
             ((worldPos.y + bottomEdgeWorldPos) / bounds.size.y) + 1
         );
    }







}

public static class ExtensionMethod
{
    public static float Brightness(this Color color)
    {
        float h, s, v;
        Color.RGBToHSV(color, out h, out s, out v);
        return v;
    }
}