using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Transform[] pointsToSpawn;
    [SerializeField] private InteractiveObject[] objectsToSpawn;


    private void Start()
    {
        SpawnInteractiveObjects();
    }

    private void SpawnInteractiveObjects()
    {

        if (pointsToSpawn == null || pointsToSpawn.Length == 0)
        {
            return;
        }

        if (objectsToSpawn == null || objectsToSpawn.Length == 0)
        {
            return;
        }
        foreach (var point in pointsToSpawn)
        {
            int randomObjectIndex = UnityEngine.Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[randomObjectIndex], point.position, point.rotation,parent: transform);
           

        }
    }


    public void RespawnSpawnedObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        SpawnInteractiveObjects();
    }
}
