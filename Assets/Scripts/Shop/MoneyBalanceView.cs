using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalanceView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _balance;

    private void OnEnable()
    {
        _balance.text = _player.Money.ToString();
        _player.OnMoneyChanged += OnPlayerMoneyChanged;
    }

    private void OnDisable()
    {
        _player.OnMoneyChanged -= OnPlayerMoneyChanged;
    }

    private void OnPlayerMoneyChanged(int money)
    {
        _balance.text = money.ToString();
    }
}
