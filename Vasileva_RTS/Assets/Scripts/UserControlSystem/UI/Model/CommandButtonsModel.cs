using System;
using Zenject;
using UnityEngine;

public class CommandButtonsModel
{
    public event Action<ICommandExecutor> OnCommandAccepted;
    public event Action OnCommandSent;
    public event Action OnCommandCancel;

    [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
    [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
    [Inject] private CommandCreatorBase<IMoveCommand> _mover;
    [Inject] private CommandCreatorBase<IPatrolCommand> _patroller;
    [Inject] private CommandCreatorBase<IStopCommand> _stopper;

    private bool _commandIsPending;

    public void OnCommandButtonClicked(ICommandExecutor commandExecutor, ICommandsQueue commandsQueue)
    {
        if (_commandIsPending)
        {
            processOnCancel();
        }
        _commandIsPending = true;
        OnCommandAccepted?.Invoke(commandExecutor);

        _unitProducer.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
        _attacker.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
        _mover.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
        _patroller.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
        _stopper.ProcessCommandExecutor(commandExecutor, command => ExecuteCommandWrapper(command, commandsQueue));
    }

    public void ExecuteCommandWrapper(object command, ICommandsQueue commandsQueue)
    {
        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            commandsQueue.Clear();

        commandsQueue.EnqueueCommand(command);
        _commandIsPending = false;
        OnCommandSent?.Invoke();
    }

    public void OnSelectionChanged()
    {
        _commandIsPending = false;
        processOnCancel();
    }

    private void processOnCancel()
    {
        _unitProducer.ProcessCancel();
        _attacker.ProcessCancel();
        _mover.ProcessCancel();
        _patroller.ProcessCancel();
        _stopper.ProcessCancel();

        OnCommandCancel?.Invoke();

    }


}
