using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{

    public int coinCount;
    public Text coinText;
    public GameObject bridge;
    private bool bridgeDestroyed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ": " + coinCount.ToString();
        if (coinCount == 10 && !bridgeDestroyed)
        {
            bridgeDestroyed = true;
            Destroy(bridge);
        }
    }
    
}
