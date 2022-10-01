using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audio;
    int currentSong = 0;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        StartCoroutine(playAudioSequentially());
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying == false)
        {
            currentSong++;
            if (currentSong >= songs.Length)
            {
                currentSong = 0;
                audio.clip = songs[currentSong];
                audio.Play();
            }
        }
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < songs.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            audio.clip = songs[i];

            //3.Play Audio
            audio.Play();

            //4.Wait for it to finish playing
            while (audio.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }
}
