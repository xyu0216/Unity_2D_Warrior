using UnityEngine;
using UnityEngine.SceneManagement;//引用場景管理API


public class Scenecontroller : MonoBehaviour
{ 
    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundclip;


    public void StartGame()
    {
        aud.PlayOneShot(soundclip,2);
        //延遲呼叫(方法名稱,延遲秒數)
        Invoke("DelayStartGame", 1.5f);
    
      
    }

    public void BackToMenu()
    {
        aud.PlayOneShot(soundclip,2);

        Invoke("DelayBackToMenu", 1.5f);
                
    }
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        aud.PlayOneShot(soundclip,2);

        Invoke("DelayQuitGame", 1.5f);

    }

    private void DelayStartGame()
    {
        //場景管理器.載入場景(場景名稱)
        SceneManager.LoadScene("遊戲場景");

    }
    private void DelayBackToMenu()
    {
        SceneManager.LoadScene("選單");
    }
    private void DelayQuitGame()
    {
        Application.Quit();
    }



}



