using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask wallLayer;
    private float wallJumpCooldown;
    private float horizontalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        if (body == null)
        {
            Debug.LogError("Rigidbody2D não foi encontrado");
        }
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log("Velocidade Horizontal: " + body.linearVelocity.x);

        // mudando o jogador quando ele tiver se movendo pra esquerda e pra direita
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // setando os parametros do animator
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        print(onWall());

        // lógica do pulo na parede
        if (wallJumpCooldown > 0.2f)
        {
            float currentSpeed = speed;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                currentSpeed *= 1.5f;
            }

            body.linearVelocity = new Vector2(horizontalInput * currentSpeed, body.linearVelocity.y);
            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            Debug.Log("Pulo: " + body.linearVelocity.y);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.linearVelocity = new Vector2(-transform.localScale.x * 10, 0);
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else
                body.linearVelocity = new Vector2(-transform.localScale.x * 3, 6);
            wallJumpCooldown = 0;
        }
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAtack()
    {
        return horizontalInput==0 && isGrounded() && !onWall();
    }

}