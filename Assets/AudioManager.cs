using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;
    public AudioClip clip;

[Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

 /* [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
     [Range(0f, 0.5f)]
    public float randomPitch = 0.1f; */

    public bool loop;

    private AudioSource source;

//Kutsuu clippiä
    public void SetSource ( AudioSource _source){
    source = _source;
    source.clip = clip;
    }

    public void Play() {
        source.volume = volume; //* (1 + randomPitch.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch; //* (1 + randomPitch.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
        source.loop = loop;
    }
}
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    void Awake(){
        if(instance != null){
            Debug.LogError("More than one AudioManager in the scene.");
        }else {

        
        instance = this;
        }
    }

    [SerializeField]
Sound[] sounds;

void Start(){
    for (int i = 0; i<sounds.Length; i++){
        GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
       sounds[i].SetSource(_go.AddComponent<AudioSource>());
    }
  PlaySound("Background");
}

public void PlaySound(string _name){
    for(int i = 0; i<sounds.Length; i++){
        if (sounds[i].name == _name){
            sounds[i].Play();
            return;
        }
    }
    //no sound with _name
    Debug.LogWarning("AudioManager: SOund not found in list: " + _name);
}
   
}
