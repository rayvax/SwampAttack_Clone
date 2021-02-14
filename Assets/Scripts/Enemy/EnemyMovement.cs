using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : State
{
    [SerializeField] private float _speed;


    private void OnEnable()
    {
        myAnimator.Play("Run");
    }

    private void Update()
    {
        if (Target == null)
            return;

        var targetPos = Target.transform.position;
        targetPos.y = transform.position.y;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
    }
}
