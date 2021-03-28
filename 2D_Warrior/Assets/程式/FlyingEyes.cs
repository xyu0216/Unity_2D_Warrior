using UnityEngine;
using System.Collections;

public class FlyingEyes : MonoBehaviour
{
    [Header("���ʳt��"), Range(0, 1000)]
    public float Speed = 7;
    [Header("�����d��"), Range(0, 100)]
    public float Atkrange = 2;
    [Header("�����O"), Range(0, 1000)]
    public float Atk = 15;
    [Header("�����N�o"), Range(0, 10)]
    public float AtkCD = 2.0f;
    [Header("��������ǰe�ˮ`"), Range(0, 10)]
    public float Atkdelay = 0.7f;
    [Header("��q"), Range(0, 5000)]
    public float HP = 250;
   
    [Header("�����d��첾")]
    public Vector3 offsetAttack;
    [Header("�����d��j�p")]
    public Vector3 sizeAttack;

     private Animator Ani;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    
    private Player player;
    private float timer;
    private CameraController2D cam;
       
    private void Start()
    {
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
        Rig = GetComponent<Rigidbody2D>();
     
        player = FindObjectOfType<Player>();            //�z�L�����M��}��<����>  ---����O���Ƹ}��
        cam = FindObjectOfType<CameraController2D>();
    }

      private void Update()
    {
        if (Ani.GetBool("���`�}��")) return;           //�p�G ���`�}�� �w�Ŀ� �N���X
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
        HP -= damage;                        //����
        Ani.SetTrigger("����Ĳ�o");          //���˰ʵe
       
               
        if (HP <= 0) Dead();
    }
     
     private void Dead()
    {
                          //Ĳ�o���`�ƥ�

        HP = 0;
        
        Ani.SetBool("���`�}��", true);
        //���o����<���n�I��>().�Ұ�= �_
        GetComponent<CapsuleCollider2D>().enabled = false;
        Rig.Sleep();                                             //����.�ε�
        Rig.constraints = RigidbodyConstraints2D.FreezeAll;      //����.����=����.�ᵲ����

    }

     private void Move()
    {
        AnimatorStateInfo Info = Ani.GetCurrentAnimatorStateInfo(0);
        if (Info.IsName("��������") || Info.IsName("��������")) return;

        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);

        float dis = Vector2.Distance(transform.position, player.transform.position);

        if (dis > Atkrange)
        {
            //����.���ʮy��(�y��+�e��*�@��*�t��)
            Rig.MovePosition(transform.position + transform.right * Time.deltaTime * Speed);
        }
        else
        {
            Attack();
        }

        Ani.SetBool("����}��", Rig.velocity.magnitude > 0);
    }

    private void Attack()

    {
        Rig.velocity = Vector3.zero;

        if (timer < AtkCD)                       //�p�G�p�ɾ�<�����N�o
        {
            timer += Time.deltaTime;           //�֥[�p�ɾ�
        }
        else                                   //�_�h�p�ɾ�>=�����N�o
        {
            Ani.SetTrigger("����Ĳ�o");        //����
            timer = 0;                         //�p�ɾ��k�s

            StartCoroutine(DelaySendDamage());
        }
    }
     private IEnumerator DelaySendDamage()
    {
        //���ݩ���ɶ�
        yield return new WaitForSeconds(Atkdelay);
        //�I������=2d���z.�����л\�ϰ�(�����I.����.�ؤo.�ϼh)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack, 0, 1 << 10);
        //�p�G �I�쪫�� �s�b ���a.����(�����O)
        if (hit) player.Damage(Atk);
        StartCoroutine(cam.shakeCamera());

                
    }

}
