using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : IState
{
    private AIController aIController;
    public StateType Type => StateType.Chase;

    public ChaseState(AIController aIController)
    {
        this.aIController = aIController;
    }

    public void Enter()
    {
        aIController.Animator.SetBool("isChasing", true);
    }

    public void Execute()
    {
        if(!aIController.CanSeePlayer())
        {
            aIController.StateMachine.TransitionToState(StateType.Patrol);
            return;
        }

        if(aIController.IsPlayerInAttackRange())
        {
            aIController.StateMachine.TransitionToState(StateType.Attack);
            return;
        }

        aIController.Agent.destination = aIController.Player.position;
    }

    public void Exit()
    {

    }
}
