using UnityEngine;

public class Log : MonoBehaviour
{
    public float currentRotation;
    public float rotationSpeed;
    public ParticleSystem boom;
    void Update()
    {
        currentRotation += rotationSpeed * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
    public void LogChange()
    {
        for(var i= gameObject.transform.childCount-1; i>=0 ; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
        boom.Play();
    }
}
