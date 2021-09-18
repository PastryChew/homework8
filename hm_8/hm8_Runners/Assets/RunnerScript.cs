using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerScript : MonoBehaviour
{
    
    public Vector3[] points = new Vector3[4];
    public Transform[] gg;

    

    private Vector3 target;

    public float speed;

    public bool forward;

    private int massNum = 0;


   
    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = gg[i].position;
        }
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
