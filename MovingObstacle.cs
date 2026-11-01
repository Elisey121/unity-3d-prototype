using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private int damageValue = 25; 
    [SerializeField] private float speed = 3f;    
    [SerializeField] private float moveDistance = 4f; 

    private Vector3 startPosition;
    private int direction = 1;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            direction *= -1; 
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageValue);
            }
        }
    }
}