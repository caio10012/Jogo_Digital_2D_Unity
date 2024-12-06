using UnityEngine;

public class FeatherCollectable : MonoBehaviour
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
        PlayerFlying Player = collision.GetComponent<PlayerFlying>();
        if (collision.tag == "Player")
        {
            Player.EnableFly();
            gameObject.SetActive(false);
        }
    }
}
