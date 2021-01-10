using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度")]
    public float speed = 7.5f;

    ///追蹤目標物件
    private void Track()
    {
      Vector3 posA = target.position;                                   //取得玩家座標
      Vector3 posB = transform.position;                                //取得攝影機座標
        posA.z = -10;                                                   //Z軸改為-10

        posB = Vector3.Lerp(posB, posA, 0.5f * speed * Time.deltaTime); //差值
        transform.position = posB;                                      //更新攝影機座標

    }
    
    //延遲更新:在Update動作之後動作,追蹤
    private void LateUpdate()
    {
        Track();
    }

}
