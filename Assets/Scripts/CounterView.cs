using System.Collections;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;

    private Counter _counter;
    private bool _isCounting = true;

    private void Start()
    {
        _counter = new Counter();
        _counter.OnCountChanged += UpdateCounterText;
        StartCoroutine(UpdateCounter());

        // Добавляем обработчик клика по тексту
        if (_counterText != null)
        {
            var button = _counterText.GetComponentInParent<UnityEngine.UI.Button>();
            if (button == null)
            {
                button = _counterText.gameObject.AddComponent<UnityEngine.UI.Button>();
            }
            button.onClick.AddListener(ToggleCounting);
        }
    }

    private IEnumerator UpdateCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (_isCounting)
            {
                _counter.Increment();
            }
        }
    }

    private void UpdateCounterText(float count)
    {
        if (_counterText != null)
        {
            _counterText.text = "Count: " + count;
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;
    }
}
