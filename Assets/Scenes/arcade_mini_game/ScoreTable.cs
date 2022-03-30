using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    [SerializeField] float templateHeight = 30f;

    string[] FirstName = new string[] {"Yang", "Jiaxing", "Yu", "Siqi", "Yiming", "Jiyan", "Wenjuan", "Haoxiang", "Jianyi", "Xintong", "Xiao", "Zihe", "Aodong", "Rui", "Jie", "Jing", "Han", "Zihan", "Haoran", "Wanjie", "Rongshuang", "Mingfeng", "Zeyu", "Yunze", "Yelei", "Shuyin", "Kun", "Qingfeng", "Yufeng", "Yiling", "Qike",
                                                };
    string[] LastName = new string[] {"Zhao", "Yang", "Wang", "Wu", "Liu", "Li", "Jia", "Dong", "Du", "Huang", "He", "Lv", "Qi", "Zhou", "Su", "Guo", "Xia", "Chen", "Sun",
                                                };
    List<string> names;
    List<int> scores;

    [SerializeField] int numberOfNames = 9;
    [SerializeField] int highestRank = 5;

    // Start is called before the first frame update
    void Start()
    {
        TranscriptGenerate();

        entryContainer = transform.Find("scoreEntryContainer");
        if (!entryContainer)
        {
            Debug.LogError("scoreEntryContainer not find");
        }
        entryTemplate = entryContainer.Find("scoreEntryTemplate");
        if (!entryTemplate)
        {
            Debug.LogError("scoreEntryTemplate not find");
        }

        entryTemplate.gameObject.SetActive(false);

        
        for(int i = 0; i < numberOfNames + 1; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entrtRectTransform = entryTransform.GetComponent<RectTransform>();
            entrtRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + " TH";break;

                case 1: rankString = "1 ST"; break;
                case 2: rankString = "2 ND"; break;
                case 3: rankString = "3 RD"; break;
            }

            entryTransform.Find("posText").GetComponent<Text>().text = rankString;
            entryTransform.Find("nameText").GetComponent<Text>().text = names[i];
            entryTransform.Find("scoreText").GetComponent<Text>().text = scores[i].ToString();



        }


    }

    private void TranscriptGenerate()
    {

        List<string> selectedFirstName = SelectName(FirstName);
        List<string> selectedLastName = SelectName(LastName);

        names = new List<string>();
        for (int i = 0; i < numberOfNames; i++)
        {
            names.Add(selectedFirstName[i] + " " + selectedLastName[i]);

        }

        int randomRank = Random.Range(highestRank, numberOfNames + 1);
        names.Insert(randomRank, "YOU");

        scores = new List<int>();

        for (int i = 0; i < numberOfNames + 1; i++)
        {
            int score = Random.Range(0, 100);
            scores.Add(score);
        }
        scores.Sort((s1, s2) => s2.CompareTo(s1));
        for (int i = 0; i < numberOfNames + 1; i++)
        {
            Debug.Log(i);
            Debug.Log(scores[i]);
            Debug.Log("-----------------");

        }

    }

    private List<string> SelectName(string[] names)
    {
        int lengthOfNames = names.Length;
        List<string> selectedName = new List<string>();
        for (int i = 0; i < numberOfNames; i++)
        {
            int rand = Random.Range(0, lengthOfNames);
            while (selectedName.Contains(names[rand]))
            {
                rand = Random.Range(0, lengthOfNames);
            }
            selectedName.Add(names[rand]);
        }

        return selectedName;
    }


    
}
