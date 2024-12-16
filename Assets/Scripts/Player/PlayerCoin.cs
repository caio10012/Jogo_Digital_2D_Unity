using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    public CoinManager cm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
        if (other.gameObject.CompareTag("GemPink"))
        {
            Destroy(other.gameObject);
            cm.coinCount += 2;
        }
        if (other.gameObject.CompareTag("GemGreen"))
        {
            Destroy(other.gameObject);
            cm.coinCount += 3;
        }
        if (other.gameObject.CompareTag("GemBrown"))
        {
            Destroy(other.gameObject);
            cm.coinCount += 4;
        }
    }
}
