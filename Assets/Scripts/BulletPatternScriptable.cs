using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletPattern")]
public class BulletPatternScriptable : ScriptableObject
{
    public float Speed = 1;
    public Vector3 Direction;
    public float Lifetime = 1;
    public enum MovementType
    {
        Straight,
        Wavy,
        Homing
    };
    public MovementType mt;
    public List<BulletBehaviour> Bullets;
    public void AddBullet()
    {
        var bul = new BulletBehaviour();
        bul.Speed = Speed;
        bul.Direction = Direction;
        bul.Lifetime = Lifetime;
        bul.mt = mt;
        Bullets.Add(bul);
    }
}
