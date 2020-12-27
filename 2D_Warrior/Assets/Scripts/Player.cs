using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float MoveSpeed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int JumpHeight = 100;
    [Header("是否在地面上"),Tooltip("是否在地面上")]
    public bool OnTheGround = false;
    [Header("子彈")]
    public GameObject Bullets;
    [Header("子彈生成點")]
    public Transform BulletSpawnPoint;
    [Header("子彈速度"), Range(0, 5000)]
    public int BulletSpeed = 800;
    [Header("開槍音效")]
    public AudioClip Fire;
    [Header("血量"),Range(0,200)]
    public float HP = 100;
    
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;


    private void Move(string direction , int speed = 100 )
    {
        print("移動方向:" + direction);
        print("移動速度:" + speed);
    }
    private void Jump(int height = 100)
    {
        print("跳躍高度" + height);
    }
    private void Shoot(string direction ,string sound)
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

    private void Start()
    {
        Move("右邊", 150);
        Move("左邊", 150);

        Jump();
        Jump(200);

        Shoot("右邊", "咻咻咻");
        Shoot("左邊", "咻咻嘿");



    }



}
