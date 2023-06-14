using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable : IHealthHolder, IIconHolder
{
    Transform PivotPoint { get; }
}
