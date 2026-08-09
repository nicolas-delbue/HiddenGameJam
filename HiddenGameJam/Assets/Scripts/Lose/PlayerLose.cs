using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            //Change so it sends event to a game manager
            CEventSystem.current.Lose(true);
        }
    }
}
