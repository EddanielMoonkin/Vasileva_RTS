using System.Threading.Tasks;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Unit is patroling from {command.From} to {command.To}");
    }
}
