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
        // Carrega o n�mero de moedas salvo
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
        if (coinCount >= 15 && !bridgeDestroyed2)
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

    // M�todo chamado quando o objeto � destru�do
    void OnApplicationQuit()
    {
        // Reseta o contador de moedas quando o jogo � reiniciado
        PlayerPrefs.DeleteKey("CoinCount");
    }
}