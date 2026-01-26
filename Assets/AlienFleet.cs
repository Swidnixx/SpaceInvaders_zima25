using UnityEngine;
using UnityEngine.UI;

public class AlienFleet : MonoBehaviour
{
    public float speed = 0.25f;
    public float moveTime = 2;
    int dir = 1;
    int stepCounter = 0;

    bool gameRun = true;

    public Leader leader;

    public Text gameOverText;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
        InvokeRepeating(nameof(Move), moveTime, moveTime);
        leader.StartLeader();
    }

    private void Update()
    {
        if(gameRun && transform.childCount == 0 && leader == null)
        {
            StopGame();
        }
    }

    public void StopGame()
    {
        gameRun = false;
        CancelInvoke(nameof(Move));
        if(leader != null) leader.StopLeader();
        gameOverText.gameObject.SetActive(true);

        Destroy(FindFirstObjectByType<Player>().gameObject);
    }

    void Move()
    {
        transform.Translate(new Vector3(speed * dir, 0, 0));
        stepCounter += dir;

        if (Mathf.Abs(stepCounter) >= 7)
        {
            dir *= -1;
            transform.Translate(new Vector3(0, -0.75f, 0));
        }
    }
}