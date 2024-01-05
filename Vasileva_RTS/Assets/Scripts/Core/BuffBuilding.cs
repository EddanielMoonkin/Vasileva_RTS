using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBuilding : MonoBehaviour, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivotPoint;

    //[SerializeField] private Transform _unitsParent;

    [SerializeField] private float _maxHealth = 350;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    private float _health = 1000;

    public void ReceiveDamage(int amount)
    {
        if (_health <= 0)
            return;
        _health -= amount;
        if (_health <= 0)
            Destroy(gameObject);

    }
}