using UnityEngine;
using UnityEngine.Audio;                           //引用音源API

public class SoundManager : MonoBehaviour
{
    [Header("音源管理")]
    public AudioMixer Mixer;


    /// <summary>
    /// 背景音樂 音量
    /// </summary>
    public void VolumeBGM(float v)
    {
        Mixer.SetFloat("VolumeBGM", v);
    }
    
    


    
}
