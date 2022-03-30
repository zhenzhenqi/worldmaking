using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void LoadIt()
    {        
        UnityEngine.SceneManagement.SceneManager.LoadScene("bus_station");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
