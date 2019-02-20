using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float")]
public class FloatVariable : Variable
{
    public float _Value;
    public float _MaxValue;
    public override object Value
    {
        get
        {
            return _Value;
        }
    }

    public override object MaxValue
    {
        get
        {
            return _MaxValue;
        }
    }
}
