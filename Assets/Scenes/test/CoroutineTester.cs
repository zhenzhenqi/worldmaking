using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("before coroutine start");
        StartCoroutine(sayhi());
        Debug.LogWarning("after coroutine start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator sayhi()
    {
        //for (int i = 0; i<4; i++)
        //{
        //    yield return new WaitForSeconds(2);
        //    Debug.LogWarning("Hello"); 

        //}

        Debug.LogWarning("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.LogWarning("Finished Coroutine at timestamp : " + Time.time);
    }
}
