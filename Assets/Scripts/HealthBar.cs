using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
        _player.ChangedHealth += OnChangedHealth;
    }

    private void OnDestroy()
    {
        _player.ChangedHealth -= OnChangedHealth;
    }

    public void OnChangedHealth()
    {
        StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        while(Mathf.Round(_slider.value) != _player.Health)
        {
            _slider.value = Mathf.Lerp(_slider.value, _player.Health,Time.deltaTime);
            yield return null;
        }

        _slider.value = Mathf.Round(_slider.value);
    }
}
