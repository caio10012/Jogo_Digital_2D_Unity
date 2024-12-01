using UnityEngine;

public class EnemyProjectile : EnemyDamage // damage every time the player touches
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);// executes logic from parent first
        gameObject.SetActive(false);// when hits, deactivates
    }
    public void ActivateProjectile()
    {
       lifetime = 0;
       gameObject.SetActive(true);
    }



}
