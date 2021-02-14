using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitRange;
    [SerializeField] private float _rangeSpread;
    [SerializeField] private bool _calculateOnlyAxisX = true;

    private float _rangeToTarget;

    private void Awake()
    {
        _transitRange += Random.Range(-1*_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Target == null)
            return;

        if (_calculateOnlyAxisX)
        {
            _rangeToTarget = Mathf.Abs(transform.position.x - Target.transform.position.x);
        }
        else
        {
            _rangeToTarget = (transform.position - Target.transform.position).magnitude;
        }

        if (_rangeToTarget < _transitRange)
            NeedTransit = true;
    }
}
