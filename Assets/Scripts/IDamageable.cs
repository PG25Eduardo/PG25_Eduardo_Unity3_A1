using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    // fields aren't allowed in interfaces!
    // everything in an interface must be implemented in the class, but fields can't be implemented
    // bool IsAlive;
    bool IsAlive { get; }

    // no access modifiers in interfaces!
    // we assume everything is public
    void Damage(DamageInfo damageInfo);
}