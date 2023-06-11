using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private SelectableValue _selectables;

    public override void InstallBindings()
    {
        Container.Bind<IAwaitable<IAttackable>>()
           .FromInstance(_attackablesRMB);
        Container.Bind<IAwaitable<Vector3>>()
           .FromInstance(_groundClicksRMB);
        Container.BindInstances(_legacyContext, _groundClicksRMB, _attackablesRMB, _selectables);
       
    }
}