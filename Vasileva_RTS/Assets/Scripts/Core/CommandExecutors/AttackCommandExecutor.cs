using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("Unit is attacking");
    }
}
    