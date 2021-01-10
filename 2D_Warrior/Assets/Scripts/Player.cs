using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float MoveSpeed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int JumpHeight = 100;
    [Header("是否在地面上"), Tooltip("是否在地面上")]
    public bool OnTheGround = false;
    [Header("子彈")]
    public GameObject Bullets;
    [Header("子彈生成點")]
    public Transform BulletSpawnPoint;
    [Header("子彈速度"), Range(0, 5000)]
    public int BulletSpeed = 800;
    [Header("開槍音效")]
    public AudioClip Fire;
    [Header("血量"), Range(0, 200)]
    public float HP = 100;

    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;

    private void Start()
    {
        //GetComponent<泛型>
        //泛型:泛指所有類型
        //EX:<Rigidbody2D>,<AudioSource>,<Animator>

        //剛體欄位=取得原件<剛體>()
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();






        Shoot("右邊", "咻咻咻");
        Shoot("左邊", "咻咻嘿");

    }
    private void Update()
    {
        GetHorizontal();
        Move();
        Jump();

    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //剛體.加速度 = 二維 (水平*速度,0,元件原本的Y軸)
        Rig.velocity = new Vector2(h * MoveSpeed, Rig.velocity.y);

        //按下 ( 按鍵 )  執行  {內容}
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform 指與此腳本同一層的transform
            //Rotation在程式裡是localEulerAngle
            transform.localEulerAngles = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        Ani.SetBool("跑步開關", h != 0);


    }


    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (OnTheGround && Input.GetKeyDown(KeyCode.Space))
        {
            Rig.AddForce(new Vector2(0, JumpHeight));     //剛體.添加推力(二維向量)
            OnTheGround = false;
        }

    }
    
       

    private void Shoot(string direction, string sound)
    {
        print("開槍方向:" + direction);
        print("開槍音效:" + sound);
    }
    private void Hurt(int bygun = 20, int bytouch = 10)
    {
        print("被槍攻擊:" + bygun);
        print("被接觸:" + bytouch);
    }
    private void Die()
    {
    }




    //取得水平軸向
    private void GetHorizontal()
    {
        //輸入.取得軸向(水平)
        h = Input.GetAxis("Horizontal");

    }

    //取得玩家水平軸向的值
    public float h;





}
