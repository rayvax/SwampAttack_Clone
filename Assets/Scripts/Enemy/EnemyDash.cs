using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delayBeforeDash;

    private float _timePast;

    private void Update()
    {
        if (Target == null)
            return;
        
        if(_timePast > _delayBeforeDash)
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        else
            _timePast += Time.deltaTime;
    }
}
