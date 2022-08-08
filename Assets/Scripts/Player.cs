using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHeal;
    [SerializeField] private UnityEvent _upHeal;
    [SerializeField] private UnityEvent _domwHeal;

    private float _heal;

    public float Heal { get { return _heal; } private set { } }
    public float MaxHeal { get { return _maxHeal; } private set { } }

    private void Start()
    {
        _heal = _maxHeal;
    }

    public void TakeDamage(float damage)
    {
        if(_heal - damage < 0)
        {
            _heal = 0;
        }
        else
        {
            _heal -= damage;
        }

        _domwHeal.Invoke();
    }

    public void Healing(float countHeal)
    {
        if(_heal + countHeal > _maxHeal)
        {
            _heal = _maxHeal;
        }
        else
        {
            _heal += countHeal;
        }

        _upHeal.Invoke();
    }
}
