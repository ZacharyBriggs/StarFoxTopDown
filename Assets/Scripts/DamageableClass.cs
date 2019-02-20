using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageableClass
{
    protected FloatVariable _health;
    public abstract void TakeDamage(float amount);
}
