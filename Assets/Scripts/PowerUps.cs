using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private float powerUpSpeed = 3.0f;

    [SerializeField] private string powerUpNames;
    private void Update()
    {
        transform.Translate(Time.deltaTime * powerUpSpeed * Vector3.down  );
        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            switch (powerUpNames)
            {
                case "TripleShot":
                    player.ActivateTripleShot();
                    Debug.Log("Power Up triple shot");
                    break;
                case "SpeedUp":
                    player.ActivateSpeedUp();
                    Debug.Log("Power Up Speed");
                    break;
                case "Shield":
                    player.ActivateShield();
                    Debug.Log("Shield power up");
                    break;
                default:
                    Debug.Log("");
                    break;
            }
            Destroy(this.gameObject);
        }
    }

    
}
