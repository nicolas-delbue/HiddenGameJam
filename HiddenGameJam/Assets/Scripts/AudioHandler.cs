using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance;

    private AudioSource m_musicSource;
    [SerializeField] private AudioSource soundEffectPrefab;
    public AudioClip mainMenuMusic;
    public AudioClip levelMusic;
    public AudioClip winMusic;
    public AudioClip lossMusic;
    private void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("Two instances of AudioHandler in Scene");
            Destroy(this.gameObject);
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
        m_musicSource = GetComponent<AudioSource>();
        m_musicSource.loop = true;
        SceneManager.activeSceneChanged += ChangeSceneMusic;

        m_musicSource.Stop();
        m_musicSource.clip = mainMenuMusic;
        m_musicSource.volume = .5f;
        m_musicSource.Play();
        //Link to win and lose
    }
    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= ChangeSceneMusic;
    }
    private void ChangeSceneMusic(Scene from, Scene to)
    {
        switch(to.buildIndex)
        {
            case 0:
                m_musicSource.Stop();
                m_musicSource.clip = mainMenuMusic;
                m_musicSource.volume = .5f;
                m_musicSource.Play();
                break;
            case 1:
                m_musicSource.Stop();
                m_musicSource.clip = levelMusic;
                m_musicSource.volume = .5f;
                m_musicSource.Play();
                break;
        }
    }
    public void WinMusic()
    {
        m_musicSource.Stop();
        m_musicSource.clip = winMusic;
        m_musicSource.Play();
    }
    public void LoseMusic()
    {
        m_musicSource.Stop();
        m_musicSource.clip = lossMusic;
        m_musicSource.Play();
    }
    public void PlaySoundEffect(AudioClip effect, Transform position, float volume)
    {
        AudioSource sfxSource = Instantiate(soundEffectPrefab, position.position, Quaternion.identity);

        sfxSource.clip = effect;
        sfxSource.volume = volume;
        sfxSource.Play();
        float clipLength = sfxSource.clip.length;
        Destroy(sfxSource.gameObject, clipLength);
    }
}
