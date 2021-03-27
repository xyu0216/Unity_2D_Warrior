using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

	public string nextLevel;

    [System.Obsolete]
    private void Start () {
		//保存進度讓玩家在下次遊玩時可以選取繼續來遊玩上次到達的關卡
		PlayerPrefs.SetString("savedLevel", Application.loadedLevelName);
	}

    //檢查是否碰到玩家，如果碰到標籤為Player的物件時要前進至下一個設定的關卡

    [System.Obsolete]
    private void OnTriggerEnter2D (Collider2D collisiion)
	{
		if(collisiion.name == "戰士")
		{
			Application.LoadLevel("遊戲場景2");
		}
	}
}
