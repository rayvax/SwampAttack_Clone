using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; private set; }
    protected Animator myAnimator { get; private set; }

    protected void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Enter(Player target)
    {
        if(!enabled)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if(enabled)
        {
            enabled = false;

            foreach (var transition in _transitions)
                transition.enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.NextState;
        }

        return null;
    }
}
