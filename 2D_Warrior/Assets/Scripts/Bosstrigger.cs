using UnityEngine;

public class Bosstrigger : MonoBehaviour
{
    [Header("魔王血條")]
    public GameObject objHP;
    [Header("魔王")]
    public GameObject objBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "戰士")
        {
            objHP.SetActive(true);
            objBoss.SetActive(true);
        }

    }


}
