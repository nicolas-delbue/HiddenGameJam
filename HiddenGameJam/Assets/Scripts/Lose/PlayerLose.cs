using UnityEngine;

public class PlayerLose : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            Debug.Log("Game Has Lost, Reset Map");
            //Game Lose Play animation? Reset
        }
    }
}
