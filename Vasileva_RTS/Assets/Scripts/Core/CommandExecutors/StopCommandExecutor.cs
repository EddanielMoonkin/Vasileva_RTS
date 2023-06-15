using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public CancellationTokenSource CancellationTokenSource { get; set; }

    public override async Task ExecuteSpecificCommand(IStopCommand command)
    {
        CancellationTokenSource?.Cancel();
    }
}
