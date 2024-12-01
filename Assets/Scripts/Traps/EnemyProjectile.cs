using UnityEngine;

public class EnemyProjectile : EnemyDamage // damage every time the player touches
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;
    private bool hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
            return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);// executes logic from parent first
        coll.enabled = false;

        if (anim != null)
            anim.SetTrigger("explode");// triggers animation
        else
            gameObject.SetActive(false);// when hits, deactivates

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public void ActivateProjectile()
    {
        hit = false;
       lifetime = 0;
       gameObject.SetActive(true);
        coll.enabled = true;
    }



}
