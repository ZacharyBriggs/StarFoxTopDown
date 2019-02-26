using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Speed;
    public BulletBehaviour ProjectilePrefab;
    private CharacterController cc;

	// Use this for initialization
	void Start ()
    {
        cc = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update ()
    {
        this.transform.position += PlayerInput.InputVector*Speed*Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            var transform1 = transform;
            var b = Instantiate(ProjectilePrefab,transform1.position, transform1.rotation);
            b.Direction = new Vector3(0, 1, 0);
        }
	}
}
