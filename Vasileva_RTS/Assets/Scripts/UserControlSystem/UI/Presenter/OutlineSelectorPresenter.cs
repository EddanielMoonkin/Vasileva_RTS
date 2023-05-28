using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectableValue;

    private Outliner[] _outliners;
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectableValue.OnSelected += OnSelected;
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
            return;

        SetSelected(_outliners, false);
        _outliners = null;

        if(selectable != null)
        {
            _outliners = (selectable as Component).GetComponents<Outliner>();
            SetSelected(_outliners, true);
        }
        else
        {
            if (_outliners != null)
                SetSelected(_outliners, false);
        }

        _currentSelectable = selectable;

        static void SetSelected(Outliner[] selectors, bool value)
        {
            if(selectors != null)
            {
                for(int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }
}
