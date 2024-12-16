using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject bridge;
    private bool bridgeDestroyed = false;
    public GameObject bridge2;
    private bool bridgeDestroyed2 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Carrega o número de moedas salvo
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinText();
        if (coinCount == 13 && !bridgeDestroyed)
        {
            bridgeDestroyed = true;
            Destroy(bridge);
        }
        if (coinCount >= 7 && !bridgeDestroyed2)
        {
            bridgeDestroyed2 = true;
            Destroy(bridge2);
        }
    }

    // Atualiza o texto das moedas
    void UpdateCoinText()
    {
        coinText.text = ": " + coinCount.ToString();
    }

    // Método chamado quando o objeto é destruído
    void OnApplicationQuit()
    {
        // Reseta o contador de moedas quando o jogo é reiniciado
        PlayerPrefs.DeleteKey("CoinCount");
    }
}