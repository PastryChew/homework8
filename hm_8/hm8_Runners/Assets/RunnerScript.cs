using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerScript : MonoBehaviour
{
    
    public Vector3[] points = new Vector3[4];

    public GameObject point1; 
    public GameObject point2; 
    public GameObject point3; 
    public GameObject point4;

    private Vector3 target;

    public float speed;

    public bool forward;

    private int massNum = 0;


   
    void Start()
    {
        points[0] = point1.transform.position;
        points[1] = point2.transform.position;
        points[2] = point3.transform.position;
        points[3] = point4.transform.position;
        target = points[massNum];
    }

    
    void FixedUpdate()
    {

        if (forward)
        {
            ForwardMove();
        }
        else if (!forward)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            BackMove();
        }
        
        
    }

    public void ForwardMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target)
        {
            if (massNum == 3)
            {
                forward = false;
            }
            else
            {
            target = points[massNum++];
            Debug.Log(massNum);
            }  
        }
    }
    public void BackMove()
    {
        if (transform.position == target)
        {
            target = points[massNum--];
            
            if (massNum == 0)
            {
                forward = true;
            }
        }

       
    }
}
