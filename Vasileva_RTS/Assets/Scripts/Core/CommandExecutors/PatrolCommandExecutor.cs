using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    
    [SerializeField] 
    private UnitMovementStop _stop;

    [SerializeField] 
    private Animator _animator;

    [SerializeField] 
    private StopCommandExecutor _stopCommandExecutor;

    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        var navMesh = GetComponent<NavMeshAgent>();
        var point1 = command.From;
        var point2 = command.To;
        while (true)
        {
            navMesh.destination = point2;
            _animator
            .SetTrigger(Animator
            .StringToHash("Walk"));
            _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await
                _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
            }
            catch
            {
                navMesh.enabled = true;
                navMesh.isStopped = true;
                navMesh.ResetPath();
                break;
            }

            var temp = point1;            
            point1 = point2;
            point2 = temp;
        }
        _stopCommandExecutor.CancellationTokenSource = null;
        _animator.SetTrigger(Animator.StringToHash("Idle")  );
    }
}

