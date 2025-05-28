using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    public GameObject[] goalPrefabs;

    public void SpawnGoalForPlayer(int playerIndex)
    {
        Vector3 position = gameObject.transform.position;
        if (playerIndex >= 0 && playerIndex < goalPrefabs.Length)
        {
            Instantiate(goalPrefabs[playerIndex], position, Quaternion.identity);
        }
    }
}