using UnityEngine;

public class GoalSpawnManager : MonoBehaviour {
    public GameObject[] goalPrefabs;

    public void SpawnGoal(int index) {
        if (index >= 0 && index < goalPrefabs.Length){
            Instantiate(goalPrefabs[index], transform.position, transform.rotation);
        }
        else {
            Debug.LogWarning("Invalid index!");
        }
    }
}
