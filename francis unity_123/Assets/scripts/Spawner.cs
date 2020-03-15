using UnityEngine;
using CreatorKitCode;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int NumberOfSpawns = 5;
    public float radius = 5;

    void Start()
    {
        LootAngle myLootAngle = new LootAngle(45);
        for (int i = 0; i < NumberOfSpawns; i++)
        {
            spawnpotion(myLootAngle.NextAngle());
        }
    }
    void AddingNumbers(float num1, float num2)
    {
        float resultingNumber;
        resultingNumber = num1 + num2;
    }
    void spawnpotion(int angle)
    {
        Vector3 spawnPosition = transform.position;
        radius = Random.value * 5; 

        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
        spawnPosition = transform.position + direction * radius;
        Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
    }
}
public class LootAngle
{
    public int startAngle;
    int angle;
    int step;

    public LootAngle(int increment)
    {
        step = increment;
        angle = startAngle;
    }
    public int NextAngle()
    {
        int currentAngle = angle;
        angle = Helpers.WrapAngle(angle + step);
        
        return currentAngle;
    }
}