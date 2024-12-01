using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3[] initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //save position
        initialPosition = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                initialPosition[i] = enemies[i].transform.position;
        }
    }
    public void ActivateRoom(bool _status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(_status);
                enemies[i].transform.position = initialPosition[i];

            }
                
                

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
