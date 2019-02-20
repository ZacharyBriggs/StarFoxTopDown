using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float Speed;
    public float Lifetime;
	
	// Update is called once per frame
	void Update ()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0)
            Destroy(this.gameObject);
        this.transform.position += new Vector3(0,Speed,0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var damageable = collision.gameObject.GetComponent<DamageableClass>();
            damageable.TakeDamage(10);
        }
    }
}
