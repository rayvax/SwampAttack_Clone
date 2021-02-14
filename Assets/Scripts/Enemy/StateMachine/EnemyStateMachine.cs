using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startingState;

    private State _currentState;
    private Player _target;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_startingState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();
        if(nextState)
            ChangeState(nextState);
    }

    private void Reset(State startingState)
    {
        _currentState = startingState;

        if(_currentState)
        {
            _currentState.Enter(_target);
        }
    }

    private void ChangeState(State nextState)
    {
        if (_currentState)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState)
            _currentState.Enter(_target);
    }
}
