using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Variables/Float")]
public class FloatVariable : Variable
{
    [FormerlySerializedAs("_Value")] public float value;
    [FormerlySerializedAs("_MaxValue")] public float maxValue;
    public override object Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = (float) value;
            onValueChanged.Invoke();
        }
    }

    public override object MaxValue
    {
        get
        {
            return maxValue;
        }
        set
        {
            maxValue = (float) value;
            this.value = maxValue;
        }
    }
}
