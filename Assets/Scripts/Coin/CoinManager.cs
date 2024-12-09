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
        // Carrega o n�mero de moedas salvo
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinText();
        if (coinCount == 10 && !bridgeDestroyed)
        {
            bridgeDestroyed = true;
            Destroy(bridge);
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