using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Moveable MoveableBall;
    [SerializeField] private int velocity;
    [SerializeField] private float initialAngleInDegree;
    [SerializeField] private float intervalAngle;
    [SerializeField] private float intervalTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchBalls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LaunchBalls()
    {
        float AngleInDegree = initialAngleInDegree;
        while (true)
        {
            
            yield return new WaitForSeconds(intervalTime);
            MoveableBall.set(velocity, AngleInDegree);
            Moveable newMoveableBall = Instantiate(MoveableBall, transform.position, Quaternion.identity);
            newMoveableBall.transform.parent = transform;
            AngleInDegree += intervalAngle;
        }
        
    }
}
