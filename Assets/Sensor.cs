using UnityEngine;

public class Sensor : MonoBehaviour
{
    public AlienFleet fleet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Alien"))
        {
            fleet.StopGame();
        }
    }
}
