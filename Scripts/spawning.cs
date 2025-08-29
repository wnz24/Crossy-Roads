using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject[] carPrefabs;       // Car prefabs
    public Transform[] spawnPoints;       // Spawn points on the ground
    public float carSpeed = 10f;          // Speed of cars
    public float spawnInterval = 5f;      // Time between spawns


    void Start()
    {
        InvokeRepeating("SpawnCars", 1f, spawnInterval);
    }
    private void Update()
    {
        if(GameManager.Instance.isGameOver)
        {
            CancelInvoke("SpawnCars");
        }
    }

    void SpawnCars()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject carPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];
            GameObject newCar = Instantiate(carPrefab, spawnPoint.position, carPrefab.transform.rotation);

          
            CarMovement movement = newCar.AddComponent<CarMovement>();
            movement.speed = carSpeed;

          if(spawnPoint.position.x < 0)
            {
                movement.speed = carSpeed;
                newCar.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
          if(spawnPoint.position.x > 0)
            {
                movement.speed = -carSpeed;
                newCar.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
                
        }
    }
}
public class CarMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if(GameManager.Instance.isGameOver)
        {
            return;
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if(transform.position.x < -47.5f)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > 47.5f)
        {
            Destroy(gameObject);
        }
    }
}


