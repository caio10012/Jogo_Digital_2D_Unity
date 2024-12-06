using UnityEngine;

public class PlayerFlying : MonoBehaviour
{
    [Header("Flying Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float flySpeed = 10f;
    private bool canFly = false;
    [SerializeField] private float flyDuration = 0f;
    [SerializeField] private float maxFlyDuration = 5f;

    private Rigidbody2D rb;
    private MonoBehaviour[] otherMovementScripts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        otherMovementScripts = GetComponents<MonoBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canFly)
        {
            flyDuration -= Time.deltaTime;
            if (flyDuration <= 0)
            {
                canFly = false;
                EnableOtherMovementScripts(true);
            }
        }
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        if (canFly)
        {
            if (Input.GetKey(KeyCode.P))
            {
                movement.y = 1;
            }
            else
            {
                movement.y = moveVertical;
            }
        }

        rb.linearVelocity = movement * (canFly ? flySpeed : speed);
    }

    public void EnableFly()
    {
        canFly = true;
        flyDuration = maxFlyDuration;
        EnableOtherMovementScripts(false);
    }

    private void EnableOtherMovementScripts(bool enable)
    {
        foreach (var script in otherMovementScripts)
        {
            if (script != this)
            {
                script.enabled = enable;
            }
        }
    }
}