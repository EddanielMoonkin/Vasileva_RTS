using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;


public sealed class CommandButtonsPresenter : MonoBehaviour
{
    //[SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;

    [Inject] private CommandButtonsModel _model;
    [Inject] private IObservable<ISelectable> _selectable;
 
    private ISelectable _currentSelectable;

    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;

        _selectable.Subscribe(onSelected);
        /*_selectable.OnNewValue += onSelected;
        onSelected(_selectable.CurrentValue);*/        
    }

    private void onSelected(ISelectable selectable)
    {   
        if(_currentSelectable == selectable)
        {
            return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }
        _currentSelectable = selectable;

        _view.Clear();
        if(_selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            
            var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, queue);
        }
    }
}
