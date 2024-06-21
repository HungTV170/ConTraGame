using UnityEngine;

public class PredictCollision : MonoBehaviour
{
    public string GROUND_TAG = "ground"; // Tag của chướng ngại vật

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
   
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(GROUND_TAG);


        foreach (GameObject obj in objectsWithTag)
        {
            Collider2D collider = obj.GetComponent<Collider2D>();

            if (collider != null)
            {
                // Kiểm tra nếu nhân vật đang nhảy lên
                if (rb.velocity.y > 0 && transform.position.y < obj.transform.position.y)
                {
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
                }
                // Kiểm tra nếu nhân vật đang rơi xuống
                else if (rb.velocity.y < 0 && transform.position.y > obj.transform.position.y)
                {
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider,false);
                }
            }

            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y < collision.transform.position.y && collision.gameObject.CompareTag(GROUND_TAG))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}

