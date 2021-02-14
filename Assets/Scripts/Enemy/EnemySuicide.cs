using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemySuicide : State
{
    [SerializeField] private int _suicideDamage;

    private Enemy _enemy;

    private void Awake()
    {
        base.Awake();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        Target.TakeDamage(_suicideDamage);
        myAnimator.SetTrigger("Suicide");
        StartCoroutine(Die(1));
    }

    private IEnumerator Die(float delay)
    {
        yield return new WaitForSeconds(delay);
        _enemy.Die();
    }
}
