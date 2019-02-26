using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
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

    private GameObject Player;

    public MovementType mt = MovementType.Straight;

    void Start()
    {
        if (mt == MovementType.Homing)
        {
            Speed *= 10;
            Player = GameObject.Find("Player");
        }

    }
    // Update is called once per frame
	void Update ()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0)
            Destroy(this.gameObject);
        if(mt == MovementType.Straight)
            this.transform.position += Direction * Speed * Time.deltaTime;
        if (mt == MovementType.Wavy)
            this.transform.position += new Vector3(Mathf.Sin(Direction.x), Mathf.Sin(Direction.y), Mathf.Sin(Direction.z))*Speed*Time.deltaTime;
        if(mt== MovementType.Homing)
        {
            Direction = Player.transform.position - transform.position;
            Direction.Normalize();
            var rb2d = this.GetComponent<Rigidbody2D>();
            rb2d.AddForce(Direction * Speed * Time.deltaTime,ForceMode2D.Force);
        }
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
