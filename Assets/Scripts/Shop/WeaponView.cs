﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    private Weapon _weapon;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnBuyButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnBuyButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _label.text = _weapon.Label;
        _price.text = "$" + _weapon.Price;
        _icon.sprite = _weapon.Icon;
    }

    private void OnBuyButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBought)
            _sellButton.interactable = false;
    }
}
