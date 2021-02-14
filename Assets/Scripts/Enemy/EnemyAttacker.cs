using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : State
{
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        myAnimator.SetBool("IsAttacking", true);
    }

    private void OnDisable()
    {
        myAnimator.SetBool("IsAttacking", false);
    }

    public void TryStrikeTarget()
    {
        if(Target)
            Target.TakeDamage(_damage);
    }
}
