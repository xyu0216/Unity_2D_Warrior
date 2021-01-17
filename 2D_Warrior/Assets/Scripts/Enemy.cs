using UnityEngine;

//第一次套用腳本時執行
//添加元件(類型(元件),(類型(元件),(類型(元件)....
[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour

{


    [Header("移動速度"), Range(0, 1000)]
    public float Speed = 100;
    [Header("攻擊範圍"), Range(0, 100)]
    public float Atkrange = 10;
    [Header("攻擊力"), Range(0, 1000)]
    public float Atk = 10;
    [Header("血量"), Range(0, 5000)]
    public float HP = 2500;


    private Animator Ani;
    private AudioSource Aud;
    private Rigidbody2D Rig;

    private void Start()
    {
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();

    }

    
    public void Damage(float damage)
     {
      HP-= damage;                      //遞減
      Ani.SetTrigger("受傷觸發");       //受傷動畫
    }

}

   

