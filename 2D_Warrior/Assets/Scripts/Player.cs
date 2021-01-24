using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float MoveSpeed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int JumpHeight = 1000;
    [Header("是否在地面上"), Tooltip("是否在地面上")]
    public bool OnTheGround = false;
    [Header("子彈")]
    public GameObject Bullets;
    [Header("子彈生成點")]
    public Transform BulletSpawnPoint;
    [Header("子彈速度"), Range(0, 5000)]
    public int BulletSpeed = 800;
    [Header("子彈傷害"), Range(0, 5000)]
    public float BulletDamage =50;
    [Header("開槍音效")]
    public AudioClip Fire;
    [Header("血量"), Range(0, 200)]
    public float HP = 100;
    [Header("地面判定位移")]
    public Vector3 offset;
    [Header("地面判定半徑")]
    public float radius = 0.3f;
    [Header("鑰匙音效")]
    public AudioClip Soundkey;


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
        Aud = GetComponent<AudioSource>();
        
             }
    private void Update()
    {
        GetHorizontal();
        Move();
        Jump();
        Shoot();
        
    }
    private void OnDrawGizmos()
    {
        //圖示.顏色(指定顏色)
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        //圖示.繪製球體(中心點.半徑)
        Gizmos.DrawSphere(transform.position+offset,radius);
        
    }
    /// <summary>
    /// 觸發事件:進入時觸發一次
    /// </summary>
    /// <param name="collision">碰到的物件資訊</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
       //如果  碰到的標籤  為  鑰匙
        if (collision.tag=="鑰匙")
        {
            //刪除  (一定要放 Gameobject)
           Destroy(collision.gameObject);
           Aud.PlayOneShot(Soundkey, Random.Range(1.2f, 1.8f));

        }
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
            Ani.SetTrigger("跳躍觸發");                          
        }
        Collider2D hit = Physics2D.OverlapCircle(transform.position+ offset,radius,1<<9);
        //如果 碰到的物件 存在 就將 是否在地面上設定為 是
        if (hit)
        {
            OnTheGround = true;
        }
        //否則 沒有碰到物件 就將 是否在地面上設定為 否
        else
        {
            OnTheGround = false;
        }

        Ani.SetFloat("跳躍",Rig.velocity.y);          //動畫控制器.設定浮點數(參數.值)
        Ani.SetBool("是否在地面上", OnTheGround);


    }


    /// <summary>
    /// 開槍
    /// </summary>
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))                       //如果按下左鍵.手機為觸控
        {
            //音效來源.播放一次音效(音效片段.音量)
            Aud.PlayOneShot(Fire, Random.Range(1.2f, 2.1f));
            //暫存物件 名稱 = 生成(物件,座標,角度)
            GameObject Temp =Instantiate(Bullets, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            //暫存物件.取得元件<剛體>().添加推力(生成點右邊*子彈速度+生成點上方*高度)
            Temp.GetComponent<Rigidbody2D>().AddForce(BulletSpawnPoint.right * BulletSpeed+ BulletSpawnPoint.up * 200);

            Temp.AddComponent<Bullets>().attack = BulletDamage;
        }
    }
    private void Damage(float getDamage)
    {
       
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
