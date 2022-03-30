using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Destination : MonoBehaviour
{
    public string spotName;
    public string targetSceneName;
    public bool available;

    float originalSize;

    public RectTransform labelTemplate;
    RectTransform myLabel;
    public float displyLabelThreshold = 0.7f;
    public float interactDistance = 0.2f;

    GameObject player;

    bool inEffectiveRange;

    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale.x;
        labelTemplate.gameObject.SetActive(false);
        myLabel = GameObject.Instantiate(labelTemplate);
        // myLabel.gameObject.SetActive(true);
        myLabel.transform.SetParent(labelTemplate.transform.parent);
        myLabel.GetComponentInChildren<Image>().color = GetComponent<SpriteRenderer>().color;
        myLabel.GetComponentInChildren<UnityEngine.UI.Text>().text = spotName;
        myLabel.transform.position = transform.position + new Vector3(0, 0.15f, 0);

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // transform.localScale = Vector3.one * (originalSize + (Mathf.Sin(Time.time * 2) * originalSize * 0.3f));

        float dist2player = Vector2.Distance(player.transform.position, transform.position);

        if (dist2player < displyLabelThreshold)
        {
            myLabel.gameObject.SetActive(true);

            if (dist2player < interactDistance)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
                }
            }
        }
        else
        {
            myLabel.gameObject.SetActive(false);
        }





    }
}
