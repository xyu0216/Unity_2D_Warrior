using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("鑰匙")]
    public GameObject Key;
    [Header("開門音效")]
    public AudioClip Soundopen;

    private Animator Ani;
    private AudioSource Aud;

    private void Start()
    {
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="戰士" && Key==null)
        {
            Ani.SetTrigger("開門");
            Aud.PlayOneShot(Soundopen, Random.Range(1.2f, 1.8f));
        }
    }
}

