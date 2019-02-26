using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewBulletPattern")]
public class BulletPatternScriptable : ScriptableObject
{
    [FormerlySerializedAs("Speed")] public float speed = 1;
    [FormerlySerializedAs("Direction")] public Vector3 direction;
    [FormerlySerializedAs("Lifetime")] public float lifetime = 1;
    public enum MovementType
    {
        Straight,
        Wavy,
        Homing
    };
    public MovementType mt;
    [FormerlySerializedAs("Bullets")] public List<BulletBehaviour> bullets;
    public void AddBullet()
    {
        var bul = new GameObject();
        bul.AddComponent<BulletBehaviour>();
        var bb = bul.GetComponent<BulletBehaviour>();
        bb.speed = speed;
        bb.direction = direction;
        bb.lifetime = lifetime;
        bb.mt = (BulletBehaviour.MovementType) mt;
        bullets.Add(bb);
    }
}
