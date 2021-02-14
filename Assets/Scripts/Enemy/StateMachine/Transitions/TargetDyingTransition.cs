using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDyingTransition : Transition
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
