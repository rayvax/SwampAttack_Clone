using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    public Player Target { get; private set; }
    public int Reward => _reward;
    public event UnityAction<Enemy> OnDead;

    public void Init(Player target)
    {
        Target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            OnDead?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        TakeDamage(_health);
    }
}
