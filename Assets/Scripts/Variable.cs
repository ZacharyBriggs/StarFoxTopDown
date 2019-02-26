using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Variable : ScriptableObject
{
    public abstract object Value { get; set; }
    public abstract object MaxValue { get; set; }
    public delegate void OnValueChanged();
    public OnValueChanged onValueChanged;

}
