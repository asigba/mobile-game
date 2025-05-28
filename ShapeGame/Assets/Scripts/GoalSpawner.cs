using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    public GameObject[] goalPrefabs;

    private GameObject clone;
    private int player;

    public void SpawnGoalForPlayer(int playerIndex)
    {
        Vector3 pos = gameObject.transform.position;
        player = playerIndex;
        if (playerIndex >= 0 && playerIndex < goalPrefabs.Length)
        {
            clone = Instantiate(goalPrefabs[playerIndex], pos, Quaternion.identity);
            return;
        }
    }
}