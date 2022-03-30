using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    public Material materialToUse;
    
    public Shader mk4Shader;
    // Start is called before the first frame update
    void Start()
    {
        var allRend = FindObjectsOfType(typeof(Renderer));
        foreach (Renderer r in allRend)
        {


            Material[] materials = r.materials;
            List<Material> newMatList = new List<Material>();

            for (int i = 0; i < materials.Length; i++)
            {
                Texture2D mainTex;

                if (materials[i].shader == mk4Shader)
                {
                    mainTex = materials[i].GetTexture("_Albedo") as Texture2D;
                }
                else
                {
                    mainTex = materials[i].mainTexture as Texture2D;
                }


                if (mainTex != null)
                {
                    var color = AverageColorFromTexture(mainTex);
                    float h, s, v;
                    //Color.RGBToHSV(color, out h, out s, out v);
                  //var  color = Color.HSVToRGB( Random.Range(0.2f,0.6f), 0.5f , Random.Range(0.4f,0.8f));
                    //var color = Color.HSVToRGB(Random.Range(52, 200) / 360, 1, Random.value);
                    var newMat = Instantiate(materialToUse);
                    newMat.color = color;
                    newMat.mainTexture = null;
                    newMat.SetTexture("_MainTex", null);
                    materials[i] = newMat;


                }
                else
                {
                    Debug.LogError("null tex");
                }
                //else
                //{
                //    //Debug.Log("null tex");
                //    materials[i] = materialToUse;
                //}
            }

            r.materials = materials;




        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    Color AverageColorFromTexture(Texture2D tex)
    {

        Color32[] texColors = tex.GetPixels32();

        int total = texColors.Length;

        float r = 0;
        float g = 0;
        float b = 0;

        for (int i = 0; i < total; i++)
        {

            r += texColors[i].r;

            g += texColors[i].g;

            b += texColors[i].b;

        }

        return (Color)(new Color32((byte)(r / total), (byte)(g / total), (byte)(b / total), 0));

    }
}
