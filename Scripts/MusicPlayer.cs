using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public static AudioSource Song = null;
    private AudioClip Music;
    private string cancionEle; // Nombre de la cancion seleccionada
    

    [SerializeField] private bool _conDelay;
    private float _delay = 0; //Tiempo de delay para la cansion 

    // Start is called before the first frame update
    void Start()
    {
        
        cancionEle = PlayerPrefs.GetString("cancion", "Prueba"); // Regresa la cancion almacenada en el playerprefs y si no hay ninguna por default pone prueba
        Song = this.GetComponent<AudioSource>();
        StartCoroutine(LoadAudio());
        

    }

    private IEnumerator LoadAudio()
    {
        //string SongPath = Application.persistentDataPath + "/Music/";
        string SongPath = Application.streamingAssetsPath + "/Music/";
        //string FileName = "La cucaracha.mp3";

        string FileName = cancionEle + ".mp3";
        string Fullpath = string.Format(SongPath + "{0}", FileName);
        if (_conDelay)
        {
            _delay = 3.4813f; //3.48 se calculo para la cucaracha con velocidad de 178 
        } 
        
        using (UnityWebRequest url = UnityWebRequestMultimedia.GetAudioClip(Fullpath, AudioType.MPEG))
        {
            yield return url.SendWebRequest();
            if (url.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(url.error);
            }
            else
            {
                Music = DownloadHandlerAudioClip.GetContent(url);
                Song.clip = Music;
                Song.PlayDelayed(_delay); //Con esto reprodice la musica
                
                
                
            }
        }
        

    }
}
