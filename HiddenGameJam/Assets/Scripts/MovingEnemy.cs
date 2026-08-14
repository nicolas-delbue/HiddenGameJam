using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class MovingEnemy : MonoBehaviour
{
    public Transform[] points;
    public float waitTime;
    public float speed;
    public float rotSpeed;
    public bool Cycle = true;
    private int pointNum;
    private Quaternion targetRotation;
    private bool direction = false;

    private void Start()
    {
        direction = false;
        pointNum = 0;
        StartCoroutine(Pathing());
    }

    private void FixedUpdate()
    {
        //Vector3 dir = points[pointNum].position-transform.position;
        //targetRotation = Quaternion.LookRotation(Vector3.forward, dir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed*Time.deltaTime);
    }
    private void increasePoint()
    {
        if(Cycle)
        {
            pointNum++;
            if(pointNum >= points.Length)
            {
                pointNum = 0;
            }
        }
        else
        {
            if(pointNum >= points.Length-1)
            {
                //turn on subtrack
                direction = true;
            }
            if(pointNum <= 0)
            {
                //turn on add
                direction = false;
            }
            if(direction)
            {
                pointNum--;
            }
            else
            {
                pointNum++;
            }
        }
    }

    private IEnumerator Pathing()
    {
        while (true)
        {
            if(transform.position == points[pointNum].position)
            {
                yield return new WaitForSeconds(waitTime);
                //Determine increase or decrease based on if u cycle or not
                increasePoint();
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, points[pointNum].position, speed * Time.deltaTime);
                Vector3 dir = points[pointNum].position - transform.position;
                targetRotation = Quaternion.LookRotation(Vector3.forward, dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
