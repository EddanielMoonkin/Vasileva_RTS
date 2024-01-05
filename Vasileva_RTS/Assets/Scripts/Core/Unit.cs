using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit, ISelectable, IAttackable, IDamageDealer
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivotPoint;

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private int _damage = 25;

    public int Damage => _damage;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void ReceiveDamage(int amount)
    {
        if (_health <= 0)
            return;
        _health -= amount;
        if (_health <= 0)
            Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "AttackBuff")
        {
            _damage += 10;
            Debug.Log($"Damage increased to {this._damage}");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "AttackBuff")
        {
            _damage -= 10;
            Debug.Log($"Damage decreased to {this._damage}");
        }
    }

}
