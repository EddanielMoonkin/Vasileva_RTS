using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Unit is patroling from {command.From} to {command.To}");
    }
}
