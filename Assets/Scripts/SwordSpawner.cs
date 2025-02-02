using UnityEngine;

public class SwordSpawner : MonoBehaviour
{
    public GameObject Sword;
    void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            var sword = Instantiate(Sword);
            sword.transform.parent = gameObject.transform;
        }
    }
}
