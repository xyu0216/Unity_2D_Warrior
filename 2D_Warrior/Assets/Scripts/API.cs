using UnityEngine;

public class API : MonoBehaviour
{
    public Transform traA;
    public Transform tester;
    public SpriteRenderer spr;
    public GameObject gam;
    public Transform tester1;

    

    public Camera Cam;

    private void Start()
    {
        //非靜態屬性
        //取得:
        //欄位.屬性
        print("座標:" + traA.position);

        //設定
        //欄位.屬性 指定 值
        tester.position = new Vector3(2, 0, 0);
        
        //靜態屬性
        print("攝影機數量:" + Camera.allCamerasCount);
        //非靜態屬性
        Cam.backgroundColor= new Color(0.7f, 0.2f, 0.3f);

        print("圖片顏色:" + spr.color);
        print("物件圖層:" + gam.layer);

        spr.flipX = true;
        gam.layer = 5;



    }
    private void Update()
    {
        //非靜態方法
        //使用
        //欄位.方法(對應引數)

        tester.Rotate(0, 0, 15);
        tester1.Translate(0.5f,0,0,Space.World);




    }


}
