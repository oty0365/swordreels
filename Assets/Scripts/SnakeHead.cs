using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    public List<GameObject> tailTip;
    public GameObject bodyPart;
    public ParticleSystem prt;
    public bool isLevelingUp;
    public bool isAlive;
    public ObjGenerator birdGenerator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tailTip = new List<GameObject>();
        tailTip.Add(gameObject);
        isLevelingUp = false;
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, dir);
            if (Vector2.Distance(transform.position, mousePos) > 0.3f)
            {
                rb2D.linearVelocity = transform.right * speed;
            }
            else
            {
                rb2D.linearVelocity = Vector2.zero;
            }
            if (tailTip.Count > 3)
            {
                SnakeBody.generateBoms = true;
            }
        }
        else
        {
            rb2D.linearVelocity = Vector2.zero;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            GeneratorList.Spawns.Remove(collision.transform.position);
            birdGenerator.currentOutObj--;
            Destroy(collision.gameObject);
            var body = Instantiate(bodyPart, tailTip[tailTip.Count-1].transform.position,Quaternion.identity);
            var bodyData = body.GetComponent<SnakeBody>();
            bodyData.target = tailTip[tailTip.Count - 1];
            tailTip.Add(body);
            SnakeUiManager.instance.UpdateScore(1);
        }
        else if (collision.CompareTag("Body")&&isAlive)
        {
            if(tailTip.Count > 3)
            {
                var bodyData = collision.GetComponent<SnakeBody>();
                if (bodyData.isBom)
                {
                    isAlive = false;
                    StartCoroutine(SnakeDie());
                }

            }

        }
        else if (collision.CompareTag("Wall")&&isAlive)
        {
            isAlive = false;
            StartCoroutine(SnakeDie());
        }
    }
    private IEnumerator SnakeDie()
    {
        for(var i = tailTip.Count-1;i>=0;i--)
        {
            prt.gameObject.transform.position = tailTip[i].transform.position;
            prt.Play();
            if (i == 0)
            {
                var sr = gameObject.GetComponent<SpriteRenderer>();
                sr.color = new Color(0, 0, 0, 0);
                yield return new WaitForSeconds(1f);
                SnakeUiManager.instance.GameOver();
            }
            Destroy(tailTip[i]);
            yield return new WaitForSeconds(0.19f);
        }
    }


}
