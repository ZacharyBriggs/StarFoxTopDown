using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IDamageable
{
    public FloatVariable _health;
    public FloatVariable _speed;
    public Vector3 _direction;

    void Start ()
    {
		
	}

	void Update ()
    {
        this.transform.position += _direction * _speed._Value * Time.deltaTime;
	}

    public void TakeDamage(float amount)
    {
        _health._Value -= amount;
        if (_health._Value <= 0)
            Destroy(this.gameObject);
    }

}
