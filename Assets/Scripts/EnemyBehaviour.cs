using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBehaviour : MonoBehaviour, IDamageable
{
    [FormerlySerializedAs("Health")] public float health;
    [FormerlySerializedAs("Speed")] public float speed;
    [FormerlySerializedAs("FireRate")] public float fireRate;
    public Vector3 direction;
    private FloatVariable _health;
    private FloatVariable _speed;
    private FloatVariable _fireRate;
    public BulletPatternScriptable bp;

    private void Start ()
    {
        _health = ScriptableObject.CreateInstance<FloatVariable>();
        _speed = ScriptableObject.CreateInstance<FloatVariable>();
        _fireRate = ScriptableObject.CreateInstance<FloatVariable>();
        _health.maxValue = health;
        _speed.maxValue = speed;
        _fireRate.maxValue = fireRate;
    }

    private void Update ()
    {
        _fireRate.value -= Time.deltaTime;
        if (_fireRate.value <= 0)
        {
            foreach (var bullet in bp.bullets)
            {
                Instantiate(bullet,transform.position,Quaternion.identity);
            }
            _fireRate.value = _fireRate.maxValue;
        }
        this.transform.position += direction * _speed.value * Time.deltaTime;
	}

    public void TakeDamage(float amount)
    {
        _health.value -= amount;
        if (_health.value <= 0)
            Destroy(this.gameObject);
    }

}
