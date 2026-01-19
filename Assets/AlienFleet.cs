using UnityEngine;

public class AlienFleet : MonoBehaviour
{
    public float speed = 0.25f;
    public float moveTime = 2;
    int dir = 1;
    int stepCounter = 0;

    bool gameRun = true;

    public Leader leader;

    private void Start()
    {
        InvokeRepeating(nameof(Move), moveTime, moveTime);
        leader.StartLeader();
    }

    private void Update()
    {
        if(gameRun && transform.childCount == 0)
        {
            StopGame();
        }
    }

    public void StopGame()
    {
        gameRun = false;
        CancelInvoke(nameof(Move));
        leader.StopLeader();
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