using UnityEngine;

public class 回家作業 : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float MoveSpeed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int JumpHeight = 100;
    [Tooltip("是否在地面上")]
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
    public int HP = 100;
    
    public AudioSource Source;
    public Rigidbody2D Rigidbody;
    public Animator Animate;






}
