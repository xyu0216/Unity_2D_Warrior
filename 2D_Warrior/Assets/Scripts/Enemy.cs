using UnityEngine;
using UnityEngine.UI;                  //引用UI
//第一次套用腳本時執行
//添加元件(類型(元件),(類型(元件),(類型(元件)....
[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour

{


    [Header("移動速度"), Range(0, 1000)]
    public float Speed = 3;
    [Header("攻擊範圍"), Range(0, 100)]
    public float Atkrange = 5;
    [Header("攻擊力"), Range(0, 1000)]
    public float Atk = 10;
    [Header("血量"), Range(0, 5000)]
    public float HP = 2500;
    [Header("血量文字")]
    public Text textHp;
    [Header("血量圖片")]
    public Image imgHP;


    private Animator Ani;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private float hpmax;
    private Player player;

    private void Start()
    {
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();
        hpmax = HP;
        player = FindObjectOfType<Player>();          //透過類型尋找腳本<類型>  ---不能是重複腳本
    }

    private void Update()
    {
        Move();

    }

    public void Damage(float damage)
    {
        HP -= damage;                        //遞減
        Ani.SetTrigger("受傷觸發");          //受傷動畫
        textHp.text = HP.ToString();         //血量文字.文字內容=血量.轉字串() 
        imgHP.fillAmount = HP / hpmax;       //血量圖片.血量長度=目前血量/最大血量

        if (HP <= 0) Dead();                 //如果血量小於等於0,死亡
    }
    private void Dead()
    {
        HP = 0;
        textHp.text = 0.ToString();
        Ani.SetBool("死亡開關",true);
        //取得元件<膠囊碰撞>().啟動= 否
        GetComponent<CapsuleCollider2D>().enabled = false;
        Rig.Sleep();                                             //剛體.睡著
        Rig.constraints = RigidbodyConstraints2D.FreezeAll;      //剛體.約束=約束.凍結全部

      }
    /// <summary>
    /// 追蹤玩家與面向玩家
    /// </summary>
    private void Move()
    {
        /*   判斷式寫法
        if (transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        */

        //三元運算子 -布林值? 結果1 : 結果2

        //y=x 是否大於玩家 x? 是 y為 180 , 否 y為 0
        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);
        
        //距離=二維.距離(A座標,B座標)
        float dis = Vector2.Distance(transform.position, player.transform.position);

        if (dis>Atkrange)
        {
            //剛體.移動座標(座標+前方*一偵*速度)
            Rig.MovePosition(transform.position + transform.right * Time.deltaTime * Speed);
        }
        else
        {
            Attack();
        }
        
        
        //動畫.設定布林值("走路開關",剛體.加速度.值>0)
        Ani.SetBool("走路開關", Rig.velocity.magnitude > 0);
    }
    /// <summary>
    /// 攻擊冷卻與行為
    /// </summary>
    private void Attack()
    {
        Rig.velocity = Vector3.zero;
        Ani.SetTrigger("攻擊觸發");

    }






}

   

