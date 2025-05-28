using UnityEngine;

public class Respawnable : MonoBehaviour
{
    
    private float spawnRadius = 1f;
    private int maxAttempts = 20;

    public PlayerSpawner playerSpawner;
    
    public void Respawn()
    {
        // playerSpawner.SpawnRandomPlayer(transform.position);
        // return;     
    }
}