using UnityEngine;

public class EnemyFireBallHolder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Transform enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
