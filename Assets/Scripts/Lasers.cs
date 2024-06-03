using UnityEngine;

public class Lasers : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);
        if (transform.position.y > 9.5f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
