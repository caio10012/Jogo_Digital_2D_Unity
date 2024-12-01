using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float direction;
    private bool hit;
    [SerializeField] private float speed;
    private float lifetime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);

        lifetime += Time.deltaTime;
        if(lifetime > 8) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;   
        anim.SetTrigger("explode");
    }
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        
    }  
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }   
}
