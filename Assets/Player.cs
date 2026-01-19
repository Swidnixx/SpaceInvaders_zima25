using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 5f;

    private void Update()
    {
        Move();
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        Vector2 pos = transform.position;
        // granice ekranu w jednostkach œwiata
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;
    }
}
