using UnityEngine;
using System.Collections;

public class heartDrop : MonoBehaviour
{
   private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-6, 6), Random.Range(4, 8), 0);


    }


}
