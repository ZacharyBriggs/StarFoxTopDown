using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Speed;
    public GameObject ProjectilePrefab;
    private Rigidbody2D rb2d;
    
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Speed*=1000;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.AddForce(PlayerInput.InputVector*Speed*Time.deltaTime);
        if(Input.GetButton("Fire1"))
        {
            Instantiate(ProjectilePrefab,transform.position, transform.rotation);
        }
	}
}
