using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Threading.Tasks;
using Zenject;

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    [SerializeField] private Button _produceUnitButton;

    [Inject] private DiContainer _diContainer;

    private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

    private void Update()
    {
        if(_queue.Count == 0)
        {
            return;
        }

        var innerTask = (UnitProductionTask)_queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if(innerTask.TimeLeft < 0)
        {
            removeTaskAtIndex(0);
            _diContainer.InstantiatePrefab(innerTask.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
            _produceUnitButton.enabled = true;
        }
    }

    public void Cancel(int index) => removeTaskAtIndex(index);

    private void removeTaskAtIndex(int index)
    {
        for (int i = index; i < _queue.Count - 1; i++)
        {
            _queue[i] = _queue[i + 1];
        }
        _queue.RemoveAt(_queue.Count - 1);
    }

    public override async Task ExecuteSpecificCommand(IProduceUnitCommand command) //was public override void
    {       
        _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));

        if (_queue.Count == 5)
        {
            Debug.Log("Queue is full");
            _produceUnitButton.enabled = false;
            
        }

    }
}
