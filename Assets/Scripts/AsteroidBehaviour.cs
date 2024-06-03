using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1.0f;
    [SerializeField] private float asteroidMovement = 50.0f;

    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,Time.deltaTime * rotateSpeed);
        transform.Translate(Time.deltaTime * asteroidMovement * Vector3.down );
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            player.PlayerLives();
            Destroy(this.gameObject);
        }
    }
}
