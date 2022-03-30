using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public float[] size;
    int sizeIndex = 0;
     float originalSize;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Blink());
        originalSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * (Mathf.Sin(Time.time/2f) * 4 + originalSize);
    }

    //IEnumerator Blink(){
    //    while(true){
    //        yield return new WaitForSeconds(Random.Range(1, 4));
    //        if (size.Length != 0)
    //        {
    //            transform.localScale = Vector3.one * 23;
    //            yield return new WaitForSeconds(0.1f);
    //            transform.localScale = Vector3.one * 20;
    //        }
    //    }
    //}
}
