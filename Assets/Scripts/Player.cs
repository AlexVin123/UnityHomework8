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
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
        ChangedHealth?.Invoke();
    }

    public void Heal(float countHeal)
    {
        _health = Mathf.Clamp(_health + countHeal, 0, _maxHealth);
        ChangedHealth?.Invoke();
    }
}
