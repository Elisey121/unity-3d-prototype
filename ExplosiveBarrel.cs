using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] private float destructionForceThreshold = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float impactForce = collision.relativeVelocity.magnitude;

            if (impactForce >= destructionForceThreshold)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.Die(); 
                }

                Debug.Log("БОЧКА ДЕТОНИРОВАЛА! Сила удара: " + impactForce);


                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Слишком слабый толчок. Бочка просто покатилась. Сила удара: " + impactForce);
            }
        }
    }
}