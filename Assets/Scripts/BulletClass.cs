using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{

    public float Speed = 1;
    public Vector3 Direction;
    public float Lifetime = 1;
    enum MovementType
    {
        Straight,
        Wavy
    };
}
