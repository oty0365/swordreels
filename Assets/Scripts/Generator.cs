using System.Collections.Generic;
using UnityEngine;

public class ObjGenerator : MonoBehaviour
{
    public int standardOutObj;
    public int currentOutObj;
    public int maxX;
    public int minX;
    public int maxY;
    public int minY;
    public GameObject Obj;


    void Start()
    {
        RandomSpawn();
    }
    void RandomSpawn()
    {
        while (currentOutObj < standardOutObj)
        {
            var randomTransform = RandomSpawnPoint();
            if (!GeneratorList.Spawns.Contains(randomTransform))
            {
                GeneratorList.Spawns.Add(randomTransform);
                Instantiate(Obj, randomTransform, Quaternion.identity);
                currentOutObj++;
            }
        }
    }
    Vector2 RandomSpawnPoint()
    {
        var randomY = Random.Range(minY, maxY + 1);
        var randomX = Random.Range(minX, maxX + 1);
        var randomTransform = new Vector2(randomX, randomY);
        return randomTransform;
    }
    private void Update()
    {
        if (currentOutObj < standardOutObj)
        {
            RandomSpawn();
        }
    }
}
