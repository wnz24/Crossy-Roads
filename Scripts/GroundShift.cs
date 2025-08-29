using System.Security.Cryptography;
using UnityEngine;

public class GroundShift : MonoBehaviour
{
    public Transform player;        
    public GameObject[] ground; 
    private float groundLength;    
    private int currentTile = 0;

    void Start()
    {
        if (ground.Length == 0)
        {
            Debug.LogError("No ground tiles assigned!");
            return;
        }

     
        BoxCollider col = ground[0].GetComponent<BoxCollider>();
        if (col != null)
            groundLength = col.size.z * ground[0].transform.localScale.z;
        
    }

    void Update()
    {
        
        if (player.position.z > ground[currentTile].transform.position.z + groundLength)
        {
          
            int nextTile = (currentTile + 1) % ground.Length;
            Vector3 newPos = ground[nextTile].transform.position + new Vector3(0, 0, groundLength);
            ground[currentTile].transform.position = newPos;
            currentTile = nextTile;
        }
    }
}