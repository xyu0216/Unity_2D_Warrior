using UnityEngine;
using System.Collections;

public class CameraController2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度")]
    public float speed = 7.5f;
    [Header("晃動間隔"), Range(0, 1)]
    public float shakeInterval = 0.05f;
    [Header("晃動值"), Range(0, 10)]
    public float shakeValue = 0.5f;
    [Header("晃動次數"), Range(0, 10)]
    public int shakeCount = 3;



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
    /// <summary>
    /// 晃動攝影機
    /// </summary>
    /// <returns></returns>
    public IEnumerator shakeCamera()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            transform.position += Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
            transform.position -= Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
        }
    }
}
