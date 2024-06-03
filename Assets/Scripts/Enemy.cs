using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // [SerializeField] private GameObject _enemies = null;

    [SerializeField] private float enemyMovement = 4.0f;
    private PlayerMovement _playerSystem;
    private Animator _explodeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _playerSystem = GameObject.Find("Player").GetComponent<PlayerMovement>(); //Creating reference to a GameObject from a script...
        if (_playerSystem == null)
        {
            Debug.LogError("Null Player");
        }
        _explodeAnimator = gameObject.GetComponent<Animator>();

        if (_explodeAnimator == null)
        {
            Debug.LogError("Animator is NULL!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * enemyMovement * Vector3.down );
        if(transform.position.y < -7)
        {
            transform.position = new Vector3(transform.position.x,10 , 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)  //for 2D
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            
            if (_playerSystem != null)
            {
                _playerSystem.ScoreManager(Random.Range(5,10));
            }
            _explodeAnimator.SetTrigger("OnEnemyDeath");
            enemyMovement = 0;
            Destroy(this.gameObject,2.8f); //destroy enemy
            Destroy(other.gameObject); //destroy laser
            Debug.Log("Laser Shot");
        }
        else if (other.name == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            
            _explodeAnimator.SetTrigger("OnEnemyDeath");
            enemyMovement = 0;
            Destroy(this.gameObject,2.8f);
            player.PlayerLives();
        }
    }
}
