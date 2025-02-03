using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private TrailRenderer tr;
    public float shootSpeed;
    public bool isShooted;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        rb2D.linearVelocity = Vector2.zero;
        isShooted = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!isShooted) 
        {
            isShooted=true;
            rb2D.linearVelocity = new Vector2(0, 1*shootSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Log"))
        {
            gameObject.transform.parent = collision.transform;
            rb2D.linearVelocity = Vector2.zero;
            tr.enabled = false;
            UiManager.instance.swordCount--;
            UiManager.instance.swordLeft.text = UiManager.instance.swordCount.ToString();
            
        }
        if (collision.CompareTag("Sword"))
        {
            UiManager.instance.gameOverPannel.SetActive(true);
        }
        
    }
}
