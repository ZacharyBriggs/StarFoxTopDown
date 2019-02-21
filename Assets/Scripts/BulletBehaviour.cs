using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float Speed = 1;
    public Vector3 Direction;
    public float Lifetime = 1;
    enum MovementType
    {
        Straight,
        Wavy,
        Homing
    };

    MovementType mt = MovementType.Straight;

    void Start()
    {
        mt = MovementType.Straight;
    }
    // Update is called once per frame
	void Update ()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0)
            Destroy(this.gameObject);
        if(mt == MovementType.Straight)
            this.transform.position += Direction * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable.TakeDamage(10);
        }
    }
}
