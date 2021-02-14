using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _weaponViewTemplate;
    [SerializeField] private Transform _container;

    private void Start()
    {
        foreach (var weapon in _weapons)
        {
            AddItem(weapon);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var weaponView = Instantiate(_weaponViewTemplate, _container);

        weaponView.Render(weapon);
        weaponView.SellButtonClick += OnSellButtonClick;
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if(_player.TryBuy(weapon))
        {
            weapon.Buy();
            weaponView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
