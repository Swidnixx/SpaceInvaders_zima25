using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;

    private void Start()
    {
        Destroy(gameObject, 3.5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Alien"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
