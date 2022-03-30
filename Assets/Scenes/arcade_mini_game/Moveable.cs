using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    // Start is called before the first frame update
    public int velocity;
    public float angleInDegree;

    private float xValue;
    private float zValue;

    void Start()
    {
        angleInDegree = angleInDegree % 360;
        float angleInRadius = angleInDegree * 2 * Mathf.PI / 360;
        xValue = Mathf.Cos(angleInRadius) * Time.deltaTime * velocity;
        zValue = Mathf.Sin(angleInRadius) * Time.deltaTime * velocity;
        //GetComponent<Rigidbody>().velocity = new Vector3(xValue, 0f, zValue);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xValue, 0.0f, zValue);
    }

    public void set(int velocity, float angleInDegree)
    {
        this.velocity = velocity;
        this.angleInDegree = angleInDegree;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
