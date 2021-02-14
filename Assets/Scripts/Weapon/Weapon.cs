﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBought;

    [SerializeField] protected Bullet BulletPrefab;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBought => _isBought;

    public abstract void Shoot(Vector2 firePoint, Vector2 targetPosition);

    public void Buy()
    {
        _isBought = true;
    }
}
