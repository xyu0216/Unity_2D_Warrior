﻿using UnityEngine;

public class Car : MonoBehaviour
{
    #region 練習欄位
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
    #endregion

    #region 練習方法
    //欄位語法 : 修飾詞 類型 名稱 (指定 值)
    //方法語法 : 修飾詞 傳回類型 名稱 (參數名稱,參數類型) {程式區塊 , 演算法 , 陳述式}

    // void : 無傳回  (使用此指定後不傳回任何資料)
    //自訂方法不會執行,需要呼叫才會執行

    private void Test()
    {
        //輸出方法 print
        print("安安");

    }


    #endregion

    //名稱藍色:事件
    //在特定時間會執行的方法
    //開始事件:遊戲開始時會執行一次

       
    private void Start()
    {
        //呼叫方法
        //方法名稱()
        //取得Get
        print("品牌:"+ brand);
        print("高度:"+ height);
        //設定Set
        haswindow = true;

        Test();
        //傳回方法
        //1.直接當作傳回類型使用
        print("傳回的整數:" + Ten());
        print("傳回的浮點數:" + Onepointfive());
        
        //2.儲存在變數區域內
        //區域變數:在區域或方法內可使用的欄位
        //僅限於此括號內可使用
        string myname = Name();
        print(myname);

        //呼叫時輸入 >引數
         
        Drive("前面","轟隆隆",100);
        Drive("後面","AAA",150);
        Drive("左邊","高歌離席",200);
        Drive("右邊","還敢下來呀",200);

        OpenBrush("你過來一下");
        OpenBrush("糙你媽過來一下",speed : 500);

        

    }

    

    private int Ten()
    {
       return 10;
    }
    private float Onepointfive()
    {
        return 1.5f;
    }
    private string Name()
    {
        return "Xyu";
    
}
    /// <summary>
    /// 開車方向
    /// </summary>
    /// <param name="direction">方向</param>
    /// <param name="sound">音效</param>
    /// <param name="speed">速度</param>
    private void Drive(string direction,string sound,int speed)
    {
        print("開車方向:" + direction);
        print("開車音效:" + sound);
        print("開出速度:" + speed);

    }

    //預設參數值:選填式參數
    /// <summary>
    /// 開啟雨刷
    /// </summary>
    /// <param name="speed">雨刷速度</param>
    private void OpenBrush(string sound ,int count = 2 , int speed = 100)
    {
        print("開啟雨刷");
        print("音效:"+ sound );
        print("雨刷數量:" + count);
        print("雨刷速度:" + speed );

    }
}
