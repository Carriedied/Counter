using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class Counter
{
    private float _count = 0;

    public float Count => _count;
    public event Action<float> OnCountChanged;

    public void Increment()
    {
        _count++;
        OnCountChanged?.Invoke(_count);
    }
}
