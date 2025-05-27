using UnityEngine;

public class Respawnable : MonoBehaviour
{
    private Vector3 respawnPosition;

    void Start()
    {
        respawnPosition = transform.position;
    }

    public void Respawn()
    {
        transform.position = respawnPosition;
    }
}