using System.Collections;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 25;      
    [SerializeField] private float respawnTime = 10f;  
    [SerializeField] private float rotateSpeed = 80f;    

    private BoxCollider pickupCollider;
    private GameObject visualModel;

    private void Start()
    {
        pickupCollider = GetComponent<BoxCollider>();

        if (transform.childCount > 0)
        {
            visualModel = transform.GetChild(0).gameObject;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);

                StartCoroutine(RespawnSequence());
            }
        }
    }

    private IEnumerator RespawnSequence()
    {
        if (pickupCollider != null) pickupCollider.enabled = false;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        Debug.Log("Аптечка подобрана! Начинается 10-секундный отсчет до респавна...");

        yield return new WaitForSeconds(respawnTime);

        if (pickupCollider != null) pickupCollider.enabled = true;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        Debug.Log("Аптечка успешно восстановилась на сцене!");
    }
}