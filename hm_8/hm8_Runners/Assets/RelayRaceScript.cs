using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRaceScript : MonoBehaviour
{

    public Transform[] runners = new Transform[5];
    private int runnerNum = 0;
    private float passDistance;
    public Vector3 target;
    
    public int speed = 200;
    public bool canMove = true;

    



    void Start()
    {
       
        target = runners[runnerNum + 1].position;
    }

    
    void Update()
    {
        passDistance = Vector3.Distance(runners[runnerNum].position, target);
        
        if (canMove)
        {
            Run();
        }
    }

    public void Run()
    {
      
        
        runners[runnerNum].position = Vector3.MoveTowards(runners[runnerNum].position, target, Time.deltaTime * speed);
        runners[runnerNum].LookAt(target);
        

        
        if (passDistance <= 0)
        {
            runnerNum++;

            if (runnerNum == 5)
            {
                runnerNum = 0;
            }

            if (runnerNum == 4)
            {
                target = runners[0].position;
            }
            else
            {
            target = runners[runnerNum + 1].position;
            }
            
        }

    }
   
}
