using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] GemPrefabs;
    public float spawnDistance = 5f;
    public float spawninterval = 5f;
     public float spawnChance = 0.7f; 

    void Start()
    {
        InvokeRepeating(nameof(SpawnGem), 2f, spawninterval);
    }

    void SpawnGem()
    {
        
        if (Random.value <= spawnChance)
        {
            
            int randomIndex = Random.Range(0, GemPrefabs.Length);
            GameObject selectedGemPrefab = GemPrefabs[randomIndex];

            
            Vector3 spawnPos = new Vector3(
                Random.Range(-5f, 15f),                      
                selectedGemPrefab.transform.position.y,               
                Player.transform.position.z + spawnDistance 
            );

            Instantiate(selectedGemPrefab, spawnPos, Quaternion.identity);
        }
    }
}
