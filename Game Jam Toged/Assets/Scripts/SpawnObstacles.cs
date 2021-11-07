using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnObstacles : MonoBehaviour
{
    [Header("Spawn Objects")]
    public GameObject[] obstacles;
    public GameObject medicine;

    [Header("Spawn Z Positions")]
    public float spawnMaxZ = 40f;
    public float spawnMinZ = -30f;
    public float spawnZ = 10f;
    public float deathAreaZ = -45f;
    public float distanceZ = 5f;

    [Header("Spawn X Positions")]
    public float leftX = -3f;
    public float midX = 0f;
    public float rightX = 3f;

    private float[] xPositions;
    public List<GameObject> spawnedObject;

    void Start()
    {
        xPositions = new float[3];
        xPositions[0] = leftX;
        xPositions[1] = midX;
        xPositions[2] = rightX;

        SpawnObject(10, spawnMinZ);
    }

    void SpawnObject(float spawnNumber, float spawnZPos)
    {
        float tmpSpawnZPos = spawnZPos;

        for (int i = 0; i < spawnNumber; i++)
        {
            int medicineChance = Random.Range(-5, 1);

            float posX = CalculateXPos();
            tmpSpawnZPos += distanceZ;
            Vector3 spawnPos = new Vector3(posX, 1, tmpSpawnZPos);

            if (medicineChance == 0)
            {
                spawnedObject.Add(medicine);
                Instantiate(medicine, spawnPos, Quaternion.identity);
            }
            else
            {
                int rand = Random.Range(0, obstacles.Length);
                spawnedObject.Add(obstacles[rand]);
                Instantiate(obstacles[rand], spawnPos, Quaternion.identity);
            }
        }

        StartCoroutine(SpawnObjectTimer());
    }

    private float CalculateXPos()
    {

        int randXPos = Random.Range(0, xPositions.Length);
        return xPositions[randXPos];
    }

    IEnumerator SpawnObjectTimer()
    {
        yield return new WaitForSeconds(5);
        SpawnObject(8, spawnZ);
        // Start function WaitAndPrint as a coroutine
    }
}
