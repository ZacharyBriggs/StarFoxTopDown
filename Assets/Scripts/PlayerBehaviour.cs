using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("Speed")] public float speed;
    [FormerlySerializedAs("ProjectilePrefab")] public BulletBehaviour projectilePrefab;
    private CharacterController _cc;

	// Use this for initialization
    private void Start ()
    {
        _cc = GetComponent<CharacterController>();
	}

	// Update is called once per frame
    private void Update ()
    {
        this.transform.position += PlayerInput.InputVector*speed*Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            var transform1 = transform;
            var b = Instantiate(projectilePrefab,transform1.position, transform1.rotation);
            b.direction = new Vector3(0, 1, 0);
        }
	}
}
