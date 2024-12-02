using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room Camera
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;

    // Follow the player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player
        Vector3 targetPosition = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, speed);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        Vector3 newPosition = new Vector3(_newRoom.position.x, _newRoom.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, speed);
    }
}