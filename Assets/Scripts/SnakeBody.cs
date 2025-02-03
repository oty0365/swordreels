
using System.Collections;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject target;
    public float speed;
    public float rotationSpeed;
    public Color BomedColor;
    private Color OriginColor;
    private Rigidbody2D rb2D;
    public static bool generateBoms;
    public bool isBom;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        OriginColor = sr.color;
        isBom = false;
        generateBoms = false;
        StartCoroutine(BomingFlow());
    }
    private IEnumerator BomingFlow()
    {
        if (generateBoms)
        {
            yield return new WaitForSeconds(Random.Range(0, 5f));
            if (Random.Range(0, 2) == 0)
            {
                for(var i = 0f; i <= 1.6f; i += Time.deltaTime)
                {
                    if (i > 0.9f)
                    {
                        isBom = true;
                    }
                    sr.color=Color.Lerp(sr.color, BomedColor, speed*Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(Random.Range(1, 3f));
                for (var i = 0f; i <= 1.6f; i += Time.deltaTime)
                {
                    if (i > 0.45f)
                    {
                        isBom = false;
                    }
                    sr.color = Color.Lerp(sr.color, OriginColor, speed* Time.deltaTime);
                    yield return null;
                }
                sr.color = OriginColor;

                StartCoroutine(BomingFlow());
            }
            else
            {
                StartCoroutine(BomingFlow());
            }
        }
        else
        {
            yield return null;
            StartCoroutine(BomingFlow());
        }
    }
    private void FixedUpdate()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        float adjustedSpeed = Mathf.Lerp(0, speed, Mathf.Clamp01((distance - 0.8f) / 0.65f));

        Vector2 direction = (target.transform.position - transform.position).normalized;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.fixedDeltaTime * 0.01f);
        transform.rotation = Quaternion.Euler(0, 0, angle);

        rb2D.linearVelocity = direction * adjustedSpeed;
    }
}

