using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            // Encontra o CoinManager na cena
            CoinManager coinManager = FindAnyObjectByType<CoinManager>();
            if (coinManager != null)
            {
                // Salva o número de moedas antes de mudar de cena
                PlayerPrefs.SetInt("CoinCount", coinManager.coinCount);
                PlayerPrefs.Save();
            }

            // Carrega a próxima cena no índice
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
