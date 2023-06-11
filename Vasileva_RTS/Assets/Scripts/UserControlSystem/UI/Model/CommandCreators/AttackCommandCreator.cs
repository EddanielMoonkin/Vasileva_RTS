using System;
using System.Threading;
using Zenject;

public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{
    protected override IAttackCommand createCommand(IAttackable argument) =>
        new AttackCommand(argument);
}
    