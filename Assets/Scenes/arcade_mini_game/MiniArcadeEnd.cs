using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniArcadeEnd : MonoBehaviour
{
    //ArcadeSceneManager manager;
    bool isGameEnded = false;

    Canvas TranscriptCanvas;

    AudioSource audioSource;

    //string[] FirstName = new string[] {"Yang", "Jiaxing", "Yu", "Siqi", "Yiming", "Jiyan", "Wenjuan", "Haoxiang", "Jianyi", "Xintong", "Xiao", "Zihe", "Aodong", "Rui", "Jie", "Jing", "Han", "Zihan", "Haoran", "Wanjie", "Rongshuang", "Mingfeng", "Zeyu", "Yunze", "Yelei", "Shuyin", "Kun", "Qingfeng", "Yufeng", "Yiling", "Qike",
    //                                            };
    //string[] LastName = new string[] {"Zhao", "Yang", "Wang", "Wu", "Liu", "Li", "Jia", "Dong", "Du", "Huang", "He", "Lv", "Qi", "Zhou", "Su", "Guo", "Xia", "Chen", "Sun",
    //                                            };
    //List<string> names;
    //List<int> scores;

    //[SerializeField] int numberOfNames = 9;
    //[SerializeField] int highestRank = 5;




    // Start is called before the first frame update
    void Start()
    {
        //manager = FindObjectOfType<ArcadeSceneManager>();
        TranscriptCanvas = FindObjectOfType<Canvas>();
        TranscriptCanvas.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        //TranscriptGenerate();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameEnded)
        {
            if (Input.GetKeyDown("r"))
            {
                ResetMiniGame();
            }
            else if (Input.GetKeyDown("q"))
            {
                ExitMiniGame();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isGameEnded == false)
        {
            if (audioSource)
            {
                audioSource.Play();
            }
            isGameEnded = true;
            ShowTranscript();
        }
        
        
    }

    public void ShowTranscript()
    {
        TranscriptCanvas.gameObject.SetActive(true);
    }

    public void ExitMiniGame()
    {

        SceneManager.LoadScene("arcade");
    }

    public void ResetMiniGame()
    {
        SceneManager.LoadScene("arcade_mini_game");
    }

    //private void TranscriptGenerate()
    //{
  
    //    List<string> selectedFirstName = SelectName(FirstName);
    //    List<string> selectedLastName = SelectName(LastName);

    //    names = new List<string>();
    //    for(int i = 0; i < numberOfNames; i++)
    //    {
    //        names.Add(selectedFirstName[i] + " " + selectedLastName[i]);

    //    }

    //    int randomRank = Random.Range(highestRank, numberOfNames + 1) ;
    //    names.Insert(randomRank, "YOU");

    //    scores = new List<int>();

    //    for (int i = 0; i < numberOfNames + 1; i++)
    //    {
    //        int score = Random.Range(0, 100);
    //        scores.Add(score);
    //    }
    //    scores.Sort((s1,s2)=>s2.CompareTo(s1));
    //    for(int i = 0; i < numberOfNames + 1; i++)
    //    {
    //        Debug.Log(i);
    //        Debug.Log(scores[i]);
    //        Debug.Log("-----------------");

    //    }

    //}

    //private List<string> SelectName(string[] names)
    //{
    //    int lengthOfNames = names.Length;
    //    List<string> selectedName = new List<string>();
    //    for (int i = 0; i < numberOfNames; i++)
    //    {
    //        int rand = Random.Range(0, lengthOfNames);
    //        while (selectedName.Contains(names[rand]))
    //        {
    //            rand = Random.Range(0, lengthOfNames);
    //        }
    //        selectedName.Add(names[rand]);
    //    }

    //    return selectedName;
    //}
}
