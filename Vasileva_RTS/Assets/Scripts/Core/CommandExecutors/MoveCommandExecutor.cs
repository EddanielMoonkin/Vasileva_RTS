using UnityEngine;
using UnityEngine.AI;
using System.Threading;
using System.Threading.Tasks;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;

    public override async Task ExecuteSpecificCommand(IMoveCommand command)
    {
        NavMeshAgent _navMesh = GetComponent<NavMeshAgent>();
        _navMesh.destination = command.Target;
        _animator.SetTrigger(Animator.StringToHash("Walk"));
        _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();

        try
        {
            await _stop
                .WithCancellation
                    (
                    _stopCommandExecutor
                        .CancellationTokenSource
                        .Token
                    );
        }
        catch
        {
            _navMesh.enabled = true;
            _navMesh.isStopped = true;
            _navMesh.ResetPath();
        }
        _stopCommandExecutor.CancellationTokenSource = null;
        _animator.SetTrigger(Animator.StringToHash("Idle"));
    }
}
