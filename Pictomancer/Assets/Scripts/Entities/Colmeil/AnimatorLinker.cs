using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorLinker : MonoBehaviour
{
    [SerializeField] Colmeil _cRef;
    public void PlayCast()
    {
        _cRef.AttackClosestEnemies();
    }
}
