using UnityEngine;

public class Leader : MonoBehaviour
{
    public GameObject alienBullet; //pole na prefab pocisku
    public float speed = 5.0f; //prêdkoœæ poruszania siê
    public float borderValue = 8f; //wartoœæ graniczna z lewej i prawej strony w osi x
                                   //Dziêki temu, ¿e punkt (0,0,0) znajduje siê w samym œrodku wiemy, ¿e do ka¿dej krawêdzi bêdziemy mieæ tak¹ sam¹ odleg³oœæ
    Vector3 target; //punkt, który pos³u¿y jako cel do którego pod¹¿¹ w danej chwili dowódca
    Renderer rend; //dostêp do komponentu renderer

    void Start()
    {
        //Okreœlamy pocz¹tkowy kierunek
        target = new Vector3(borderValue, transform.position.y, transform.position.z);
        rend = GetComponent<Renderer>();
        rend.enabled = false; //wy³¹czamy widocznoœæ
    }

    void Update()
    {
        Move();
    }
    //Rozpoczêcie dzia³ania dowódcy
    public void StartLeader()
    {
        Invoke("ToggleVisible", 1); //Wywo³anie w³¹czenia widocznoœci po 10 sekundach
        InvokeRepeating("Shoot", 3, 1.5f); //Wywo³anie rozpoczêcia strzelania po 11 sekundach i nastêpnie strzelanie co 4
    }
    //Wy³¹czenie dzia³añ dowódcy
    public void StopLeader()
    {
        CancelInvoke("Shoot"); //Wy³¹czenie strzelania
        rend.enabled = false;
    }
    void Shoot()
    {
        //wyliczenie pozycji, w której pojawiæ siê ma pocisk
        Vector3 pos = transform.position - new Vector3(0, 1, 0);
        //stworzenie nowego pocisku
        Instantiate(alienBullet, pos, Quaternion.identity);
    }

    void ToggleVisible()
    {
        //je¿eli komponent renderer jest w³¹czony to nale¿y wy³¹czyæ
        rend.enabled = !rend.enabled;
    }

    void Move()
    {
        //okreœlenie o jaki krok ma siê przesuwaæ postaæ
        var step = speed * Time.deltaTime;
        //przesuniêcie w stronê celu
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        //Je¿eli odleg³oœæ pomiêdzy postaci¹ a celem jest bliska zeru
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            //wylicz nowy cel, który znajdzie siê po przeciwnej stronie
            target = new Vector3(target.x * -1, transform.position.y, transform.position.z);
        }
    }

    public int life = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet b = collision.gameObject.GetComponent<Bullet>();
        if (b != null)
        {
            Destroy(b.gameObject);
            life--;
            if(life < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
