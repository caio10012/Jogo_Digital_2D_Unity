using UnityEngine;

public class PlayerEspecial : MonoBehaviour
{
    public float slowDownFactor = 0.1f;
    public float slowDownLength = 10f;
    private float normalTimeScale = 1f;
    private bool isPowerActive = false;
    private Health player;
    private Rigidbody2D rb;
    private float originalFixedDeltaTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        originalFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && !isPowerActive)
        {
            Especial();
        }
    }

    public void Especial()
    {
        if (player.currentHealth > 1)
        {
            player.TakeDamage(1);

            isPowerActive = true;
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = originalFixedDeltaTime * slowDownFactor;

            Invoke("ResetTimeScale", slowDownLength);
        }
    }

    void ResetTimeScale()
    {
        Time.timeScale = normalTimeScale;
        Time.fixedDeltaTime = originalFixedDeltaTime;
        isPowerActive = false;
    }

    void FixedUpdate()
    {
        if (isPowerActive)
        {
            // Ajuste a velocidade do jogador para compensar a escala de tempo
            Vector2 adjustedVelocity = rb.linearVelocity;
            adjustedVelocity.x /= slowDownFactor; // Compensar apenas o movimento horizontal
            rb.linearVelocity = adjustedVelocity;
        }
    }
}