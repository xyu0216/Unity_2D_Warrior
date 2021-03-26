using UnityEngine;
using UnityEngine.UI;                  
using UnityEngine.Events;              
using System.Collections;
public class Mushroom : MonoBehaviour
{

        [Header("移動速度"), Range(0, 1000)]
    public float Speed = 3;
    [Header("攻擊範圍"), Range(0, 100)]
    public float Atkrange = 5;
    [Header("攻擊力"), Range(0, 1000)]
    public float Atk = 10;
    [Header("攻擊冷卻"), Range(0, 10)]
    public float AtkCD = 2.5f;
    [Header("攻擊延遲傳送傷害"), Range(0, 10)]
    public float Atkdelay = 0.7f;
    [Header("血量"), Range(0, 5000)]
    public float HP = 2500;
    [Header("血量文字")]
    public Text textHp;
    [Header("血量圖片")]
    public Image imgHP;
    [Header("攻擊範圍位移")]
    public Vector3 offsetAttack;
    [Header("攻擊範圍大小")]
    public Vector3 sizeAttack;


    private Animator Ani;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private float hpmax;
    private Player player;
    private float timer;
    private CameraController2D cam;

        private void Start()
    {
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();
        hpmax = HP;
        player = FindObjectOfType<Player>();            //透過類型尋找腳本<類型>  ---不能是重複腳本
        cam = FindObjectOfType<CameraController2D>();
     }

    private void Update()
    {
        if (Ani.GetBool("死亡開關")) return;           //如果 死亡開關 已勾選 就跳出
        Move();

    }
        private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack);

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, Atkrange);
    }
    public void Damage(float damage)
    {
        HP -= damage;                        //遞減
        Ani.SetTrigger("受傷觸發");          //受傷動畫
        textHp.text = HP.ToString();         //血量文字.文字內容=血量.轉字串() 
        imgHP.fillAmount = HP / hpmax;       //血量圖片.血量長度=目前血量/最大血量

        if (HP <= hpmax * 0.75)
        {
            Atkrange = 20;
         }
        if (HP <= 0) Dead();
    }
    private void Dead()
    {
                             //觸發死亡事件

        HP = 0;
        textHp.text = 0.ToString();
        Ani.SetBool("死亡開關", true);
        //取得元件<膠囊碰撞>().啟動= 否
        GetComponent<CapsuleCollider2D>().enabled = false;
        Rig.Sleep();                                             //剛體.睡著
        Rig.constraints = RigidbodyConstraints2D.FreezeAll;      //剛體.約束=約束.凍結全部

    }
    private void Move()
    {
        AnimatorStateInfo Info = Ani.GetCurrentAnimatorStateInfo(0);
        if (Info.IsName("蘑菇_攻擊") || Info.IsName("蘑菇_受傷")) return;

        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);

        float dis = Vector2.Distance(transform.position, player.transform.position);

        if (dis > Atkrange)
        {
            //剛體.移動座標(座標+前方*一偵*速度)
            Rig.MovePosition(transform.position + transform.right * Time.deltaTime * Speed);
        }
        else
        {
            Attack();
        }

        Ani.SetBool("走路開關", Rig.velocity.magnitude > 0);
    }
    private void Attack()

    {
        Rig.velocity = Vector3.zero;

        if (timer < AtkCD)                       //如果計時器<攻擊冷卻
        {
            timer += Time.deltaTime;           //累加計時器
        }
        else                                   //否則計時器>=攻擊冷卻
        {
            Ani.SetTrigger("攻擊觸發");        //攻擊
            timer = 0;                         //計時器歸零

            StartCoroutine(DelaySendDamage());
        }
    }
    private IEnumerator DelaySendDamage()
    {
        //等待延遲時間
        yield return new WaitForSeconds(Atkdelay);
        //碰撞物件=2d物理.盒型覆蓋區域(中心點.角度.尺寸.圖層)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack, 0, 1 << 10);
        //如果 碰到物件 存在 玩家.受傷(攻擊力)
        if (hit) player.Damage(Atk);
        StartCoroutine(cam.shakeCamera());

                
    }



}
