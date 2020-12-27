using UnityEngine;


/// <summary>
///認識API 靜態Static
/// </summary>
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        //取得靜態屬性
        
        //語法: 類別名稱.靜態屬性 

        print("隨機值:" + Random.value);
        print("拍:" + Mathf.PI);

        //設定靜態屬性

        //語法: 類別名稱.靜態屬性 = 值

        //滑鼠指標 可見/不可見
        Cursor.visible = false;
        
        //倍速 
        Time.timeScale = 2 ;

        //使用靜態方法
        //語法:類別名稱.靜態方法 =(對應引數)
        
        print("隨機取得0-1000:" + Random.Range(0, 1000));
        print("隨機取得0-10:" + Random.Range(0f, 10f));

        int number= Mathf.Abs (-99);
        print("絕對值後的整數:" + number);

        float cos = Mathf.Cos(2.5f);
        print("COS值:" + cos);

        print("所有攝影機數量:" + Camera.allCameras);
        print("2D 的重力大小:" + Physics2D.gravity);

        Physics2D.gravity = new Vector2 (0, -20);


        Application.OpenURL("http://unity3d.com/");

        print("9.99去小數點後:" + Mathf.Floor(9.99f));

        print("兩點的距離:" + Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22, 22, 22)));

            
    }
    private void Update()
    {
        print("是否按下任意鍵:" + Input.anyKeyDown);
        //print("遊戲時間:" + Time.time);

        print("是否按下空白鍵:" + Input.GetKeyDown("space"));


    }

}
