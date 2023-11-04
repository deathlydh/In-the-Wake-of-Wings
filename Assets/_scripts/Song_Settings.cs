using UnityEngine;

public class Song_Settings : MonoBehaviour
{
    public AudioSource[] audioMassive;
    private float MusicVolueme = 1f;
    void Start()
    {
        for (int i = 0; i < audioMassive.Length; i++)
        {
            AudioSource Song = audioMassive[i];
            Song.GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < audioMassive.Length; i++)
        {
            audioMassive[i].volume = MusicVolueme;
        }
    }
    public void SetVolueme(float vol)
    {
        MusicVolueme = vol;
    }
}
