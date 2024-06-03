using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;

    private int _playerLives = 3;
    // private int shieldLives = 5;
    private SpawnManager _spawnManager;
    [SerializeField]private bool isTripleShotActive = false;
    [SerializeField]private bool isSpeedUpActive = false;
    [SerializeField]private bool isShieldActive = false;
    [SerializeField] private GameObject guard = null;
    [SerializeField] private GameObject speedThrusters = null;
    //[SerializeField] private GameObject turnLeft = null;
    [SerializeField] private GameObject shootingLasers = null;
    [SerializeField] private GameObject tripleShot = null;
    [SerializeField] private int score;

    private UiManage uiManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,-5, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UiManage>();
        guard.SetActive(false);
        speedThrusters.SetActive(false);
        if (uiManager == null)
        {
            Debug.LogError("Null ui manager");
        }
    }

    // Update is called once per frame
    void Update()
    {

        MovementControl();
        LaserShooting();
    }

    void MovementControl()
    {
        if (isSpeedUpActive == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (transform.position.y <= 0)
                {
                    transform.Translate(0, playerSpeed*2 * Time.deltaTime,  0);

                }
            }
            if (Input.GetKey(KeyCode.A) )
            {
                if (transform.position.x >= -12)
                {
                  
                    transform.Translate(-playerSpeed * 2 * Time.deltaTime, 0, 0);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x <= 12)
                {
                    transform.Translate(playerSpeed * 2 * Time.deltaTime, 0, 0);

                }
            }
            if (Input.GetKey(KeyCode.S) )
            {
                if (transform.position.y > -5)
                {
                    transform.Translate(0,-playerSpeed * 2 * Time.deltaTime, 0);
                }
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= -12)
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
            }
        }
        

        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= 12)
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);

            }
        }
        
        
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= 0)
            {
                transform.Translate(0, playerSpeed * Time.deltaTime,  0);

            }
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > -5)
            {
                transform.Translate(0,-playerSpeed * Time.deltaTime, 0);
            }
        }
        
    }

    void LaserShooting()
    {
        //GetKeyDown:- To press or use the key only once
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTripleShotActive == true)
            {
                Instantiate(tripleShot, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(shootingLasers, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
            }
            
        }
    }

    public void ActivateTripleShot()
    {
        isTripleShotActive = true;
        StartCoroutine(DeactivateTripleShot());
    }
    IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(5);
        isTripleShotActive = false;
    }
    public void ActivateSpeedUp()
    {
        isSpeedUpActive = true;
        speedThrusters.SetActive(true);
        StartCoroutine(DeactivateSpeedUp());
    }

    IEnumerator DeactivateSpeedUp()
    {
        yield return new WaitForSeconds(5);
        speedThrusters.SetActive(false);
        isSpeedUpActive = false;
    }
    public void ActivateShield()
    {
        isShieldActive = true;
        guard.SetActive(true);
    }
    public void DeactivateShield()
    {
        guard.SetActive(false);
        isShieldActive = false;
        Debug.Log("Shields Deactivated");
        
    }
    
    public void PlayerLives() //This function is used in enemy script for the Lives system....
    {
        if (isShieldActive == true)
        {
            DeactivateShield();
            Debug.Log("Saved By Shield");
            Debug.Log("Player Hit. Remaining lives = " + _playerLives);
            
            return;
        }
        _playerLives--;
        uiManager.UpdateLives(_playerLives);
        if (_playerLives < 1)
        {
            _spawnManager.StopSpawning();
            Destroy(this.gameObject);
            uiManager.UpdateLives(_playerLives);
            
        }
        Debug.Log("Player Hit. Remaining lives = " + _playerLives);

    }

    public void ScoreManager(int scorePoint)
    {
        score += scorePoint;
        uiManager.UpdateScore(score);
    }
    
}

