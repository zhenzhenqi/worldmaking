using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;
    // Start is called before the first frame update
    [SerializeField] Vector3 startPoint;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        //Debug.Log(startPoint);
    }

    private void move() 
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");
        float baseValue = Mathf.Sqrt(xValue * xValue + zValue * zValue) + 0.0000001f;
        this.transform.Translate(moveSpeed * Time.deltaTime * xValue/ baseValue, 0.0f, moveSpeed * Time.deltaTime * zValue / baseValue);
        // Debug.Log(xValue.ToString() + ", " + zValue.ToString());

        //float xValue = Input.GetAxis("Horizontal") * Time.deltaTime;
        //float zValue = Input.GetAxis("Vertical") * Time.deltaTime;

        //float baseValue = Mathf.Sqrt(xValue * xValue + zValue * zValue) + 0.000001f;


        //this.transform.Translate(moveSpeed * xValue / baseValue, 0.0f, moveSpeed * zValue / baseValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    
        
        if (other.gameObject.tag == "MoveableBall")
        {
            Debug.Log("touched");
            if (audioSource)
            {
                audioSource.Play();
            }
            transform.position = startPoint;
        }


    }
}
