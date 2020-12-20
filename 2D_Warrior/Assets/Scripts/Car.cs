using UnityEngine;

public class Car : MonoBehaviour
{
    //雙斜 註解 不會被程式讀取
    //欄位語法
    //修飾詞 類型 名稱 (指定 值)
    //int整數 float浮點數 string字串 bool布林值

    //私人的:private 
    //公開的:public

    //指定  =
    //標題 Header 
    //提示 Tooltip
    //範圍 Range
    [Header("汽車高度")]
    [Range(1,10)]
    public int height = 5;
    [Header("汽車重量"),Range(2.5f,7.5f)]
    public float weight = 3.5f;
    [Header("汽車品牌")]
    public string brand = "BMW";
    [Tooltip("這代表是否有天窗")]
    public bool haswindow = true ;

    //顏色 Color 
    public Color myColor1;
    public Color red = Color.red;
    public Color green = Color.green;
    public Color myColor2 = new Color(0.2f, 0.8f, 1.2f,3.4f);
    public Color myColor3 = new Color(0,0.3f, 0.9f, 1.6f);

    //座標 向量 2 - 4
    public Vector2 V2zero = Vector2.zero;
    public Vector2 V2A = new Vector2(5, 10);

    public Vector3 V3A = new Vector3(1, 3, 5);

    public Vector4 V4A = new Vector4(1, 3, 5, 7);

    // 圖片與音效
    public Sprite picture;
    public AudioClip sound;

    //遊戲物件與元件
    public GameObject Obja;
    public GameObject Objb;

    public Transform Tra;
    public Camera Cam;
    





} 
