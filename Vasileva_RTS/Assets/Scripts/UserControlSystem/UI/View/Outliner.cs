using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Outliner : MonoBehaviour
{
    [SerializeField] private Outline _outlineComponents;
    private bool _isSelectedCache;

    void Start() => DisableOutline();
    
    public void SetSelected(bool isSelected)
    {
        if (this == null)
            return;

        if(isSelected== _isSelectedCache)
            return;

        if (isSelected)        
            EnableOutline();        
        else
            DisableOutline();

        _isSelectedCache = isSelected;
    }

    private void EnableOutline()
    {
        _outlineComponents.enabled = true;
    }

    private void DisableOutline()
    {
        _outlineComponents.enabled = false;          
    }
}
