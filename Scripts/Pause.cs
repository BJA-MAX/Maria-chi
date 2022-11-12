using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused=false;
    private void Start()
    {
        isPaused = false;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    public void pauseApretado()
    {
        gameObject.SetActive(true);
        isPaused = true;
        MusicPlayer.Song.Pause();
    }
    public void pauseQuitar()
    {
        gameObject.SetActive(false);
        isPaused = false;
        MusicPlayer.Song.Play();
    }
}
