using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public UnityAction ChangedHealth;
    private float _health;

    public float Health { get => _health; }
    public float MaxHealth { get => _maxHealth; }

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_health - damage < 0)
        {
            _health = 0;
        }
        else
        {
            _health -= damage;
        }

        ChangedHealth?.Invoke();
    }

    public void Healing(float countHeal)
    {
        if (_health + countHeal > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += countHeal;
        }

        ChangedHealth?.Invoke();
    }
}
