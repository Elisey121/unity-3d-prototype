using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; 
    [SerializeField] private float rotateSpeed = 100f;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerWallet wallet = other.GetComponent<PlayerWallet>();

        if (wallet != null)
        {
            wallet.AddCoins(coinValue);
            Destroy(gameObject); 
        }
    }
}