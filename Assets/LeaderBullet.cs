using UnityEngine;

public class LeaderBullet : MonoBehaviour
{
    //prêdkoœæ pocisku
    public float speed = 6f;
    void Start()
    {
        //Ustawienie po jakim czasie ma zostaæ usuniêty ten pocisk
        Destroy(gameObject, 3);
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        //poruszanie sie w dó³
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
