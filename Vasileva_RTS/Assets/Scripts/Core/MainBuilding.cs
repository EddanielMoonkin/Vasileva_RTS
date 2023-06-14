using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivotPoint;

    //[SerializeField] private Transform _unitsParent;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;

    private float _health = 1000;

}    
