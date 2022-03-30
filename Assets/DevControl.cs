using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevControl : MonoBehaviour
{

    public static DevControl singleton = null;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("big_map_navigation");
        }
    }

}
