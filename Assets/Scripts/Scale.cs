using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Scale : MonoBehaviour
{
    [SerializeField] private Player _palyer;
    
    private Slider _scale;

    private void Start()
    {
        _scale = GetComponent<Slider>();
        _scale.maxValue = _palyer.MaxHeal;
        _scale.value = _palyer.MaxHeal;
    }

    public void StartUpScale()
    {
       
        StartCoroutine(UpScale());
    }

    public void StartDownScale()
    {
        
        StartCoroutine(DownScale());
    }

    private IEnumerator UpScale()
    {
        while(_scale.value != _palyer.Heal)
        {
            _scale.value = Mathf.MoveTowards(_scale.value, _palyer.Heal,Time.fixedDeltaTime);
            yield return null;
        }

        StopCoroutine(UpScale());
    }

    private IEnumerator DownScale()
    {
        while (_scale.value != _palyer.Heal)
        {
            _scale.value = Mathf.MoveTowardsAngle(_scale.value, _palyer.Heal,Time.fixedDeltaTime);
            yield return null;
        }

        StopCoroutine(DownScale());
    }
}
