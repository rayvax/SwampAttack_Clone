using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _firePoint;

    public event UnityAction<int, int> OnHealthChanged;
    public event UnityAction<int> OnMoneyChanged;
    public int Money { get; private set; }

    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;
    private int _currentHealth;

    private void Start()
    {
        ChangeWeapon(_currentWeaponIndex);
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _currentWeapon.Shoot(_firePoint.position, mousePos);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Die();
    }

    public bool TryAddMoney(int income)
    {
        if (income <= 0)
            return false;

        Money += income;
        OnMoneyChanged?.Invoke(Money);
        return true;
    }

    public bool TryBuy(Weapon weapon)
    {
        if(Money >= weapon.Price)
        {
            Money -= weapon.Price;
            OnMoneyChanged?.Invoke(Money);
            _weapons.Add(weapon);
            
            return true;
        }

        return false;
    }

    public void SwapWeapon()
    {
        if(_currentWeaponIndex == _weapons.Count - 1)
        {
            _currentWeaponIndex = 0;
        }
        else
        {
            _currentWeaponIndex++;
        }

        ChangeWeapon(_currentWeaponIndex);
    }

    private void ChangeWeapon(int weaponIndex)
    {
        _currentWeapon = _weapons[weaponIndex];
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
