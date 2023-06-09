using System;

public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        var classSpecificExecutor = commandExecutor as ICommandExecutor<T>;

        if (classSpecificExecutor != null)
            classSpecificCommandCreation(callback);

        return commandExecutor;
    }

    protected abstract void classSpecificCommandCreation(Action<T> creactionCallback);

    public virtual void ProcessCancel() { }
}
