using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : IState
{
   private AIController aIController;
   private int currentWayPointIndex = 0;

   public StateType Type => StateType.Patrol;

   public PatrolState(AIController aIController)
   {
        this.aIController = aIController;
   }

   public void Enter()
   {

   }

   private void MoveToNextWayPoint()
   {
        if(aIController.Waypoints.Length == 0)
        {
            return;
        }

        aIController.Agent.destination = aIController.Waypoints[currentWayPointIndex].position;
        currentWayPointIndex = (currentWayPointIndex + 1) % aIController.Waypoints.Length;
   }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
