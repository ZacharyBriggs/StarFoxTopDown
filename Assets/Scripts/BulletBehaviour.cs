using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletBehaviour : MonoBehaviour
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

    private GameObject _player;

    public MovementType mt = MovementType.Straight;

    private void Start()
    {
        if (mt == MovementType.Homing)
        {
            speed *= 10;
            _player = GameObject.Find("Player");
        }

    }
    // Update is called once per frame
    private void Update ()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(this.gameObject);
        switch (mt)
        {
            case MovementType.Straight:
                this.transform.position += direction * speed * Time.deltaTime;
                break;
            case MovementType.Wavy:
                this.transform.position += new Vector3(Mathf.Sin(direction.x), Mathf.Sin(direction.y), Mathf.Sin(direction.z))*speed*Time.deltaTime;
                break;
            case MovementType.Homing:
                direction = _player.transform.position - transform.position;
                direction.Normalize();
                var rb2D = this.GetComponent<Rigidbody2D>();
                rb2D.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Force);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(10);
        }
    }
}
