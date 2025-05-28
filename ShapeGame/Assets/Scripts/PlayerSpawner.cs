using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public GoalSpawner goalSpawner;

    private GameObject clone;

    void Start()
    {
        Vector3 pos = gameObject.transform.position;

        int idx = SpawnRandomPlayer(pos);
        goalSpawner.SpawnGoalForPlayer(idx);

    }

    public int SpawnRandomPlayer(Vector3 position)
    {
        int idx = Random.Range(0, playerPrefabs.Length);
        clone = Instantiate(playerPrefabs[idx], position, Quaternion.identity);
        return idx;
    }

    void Update()
    {
        if (clone == null)
        {
            int idx = SpawnRandomPlayer(gameObject.transform.position);
            goalSpawner.SpawnGoalForPlayer(idx);
        }
    }
}