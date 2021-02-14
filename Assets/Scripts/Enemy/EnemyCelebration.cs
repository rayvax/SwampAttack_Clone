using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCelebration : State
{
    private void OnEnable()
    {
        myAnimator.SetTrigger("Celebrate");
    }
}
