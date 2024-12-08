using UnityEngine;
using System.Collections;
public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckPoint;
    private Health playerHealth;
    private UIManager uiManager;

    [Header("Fall Limit")]
    [SerializeField] private float fallLimit = -50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindAnyObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFallLimit();
    }

    public void CheckRespawn()
    {
        // Check if checkpoint is available
        if (currentCheckPoint == null)
        {
            uiManager.GameOver();
            return;
        }

        // Reposition player to the checkpoint with a small vertical offset
        transform.position = currentCheckPoint.position + new Vector3(0, 1, 0);
        playerHealth.Respawn();

        // Move camera to the new room
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckPoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckPoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }

    private void CheckFallLimit()
    {
        if (transform.position.y < fallLimit)
        {
            if (currentCheckPoint != null)
            {
                StartCoroutine(RespawnWithDelay());
            }
            else
            {
                playerHealth.TakeDamage(playerHealth.currentHealth); // Mata o jogador se ele cair abaixo do limite sem checkpoint
                uiManager.GameOver();
            }
        }
    }

    private IEnumerator RespawnWithDelay()
    {
        // Desativa temporariamente a colisão para evitar cair novamente imediatamente
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.1f); // Pequeno delay antes de reposicionar
        CheckRespawn();
        yield return new WaitForSeconds(0.1f); // Pequeno delay após reposicionar
        GetComponent<Collider2D>().enabled = true;
    }
}