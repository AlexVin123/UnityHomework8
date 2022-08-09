using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Dial : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
        _player.ChangedHealth += StartChangeScale;
    }

    public void StartChangeScale()
    {
        StartCoroutine(ChangeScale());
    }

    private IEnumerator ChangeScale()
    {
        while(Mathf.Round(_slider.value) != _player.Health)
        {
            _slider.value = Mathf.Lerp(_slider.value, _player.Health,Time.deltaTime);
            yield return null;
        }

        _slider.value = Mathf.Round(_slider.value);
    }
}
