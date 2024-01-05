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
    [SerializeField] public Vector3 RallyPoint { get; set; }

    private float _health = 1000;

    public void ReceiveDamage(int amount)
    {
        if (_health <= 0)
            return; 
        _health -= amount;
        if(_health <=0)
            Destroy(gameObject);

    }

}    
