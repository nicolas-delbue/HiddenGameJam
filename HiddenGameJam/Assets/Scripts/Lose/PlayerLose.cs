using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    public AudioClip loseSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            AudioHandler.instance.PlaySoundEffect(loseSFX, transform, 1f);
            CEventSystem.current.Lose(true);
        }
    }
}
