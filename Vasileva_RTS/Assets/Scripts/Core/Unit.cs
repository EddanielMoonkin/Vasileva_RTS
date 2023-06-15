using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivotPoint;

    [SerializeField] private float _maxHealth = 10;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;

    private float _health = 7;
   
}
