using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    //將怪物打死會掉落愛心
    public GameObject heartDrop;
	//如果怪物死了要出現死亡動畫
	public GameObject deathAnim;

	public int health = 6;
    public AudioClip hurtSound;

    private bool isDead = false;
	private SpriteRenderer Spr;

	private void Start()
    {
		Spr = GetComponent<SpriteRenderer>();
	}
    void takeDamage(float amount)
	{
		if (!isDead)
		{
			GetComponent<AudioSource>().PlayOneShot(hurtSound);
			health -= 1;
			if (health <= 0)
			{
				isDead = true;
				Instantiate(deathAnim, transform.position, Quaternion.Euler(0, 180, 0));
				int randNum = Random.Range(1, 4);
				if (randNum == 2)
				{
					Instantiate(heartDrop, transform.position, Quaternion.Euler(0, 180, 0));
				}
				Destroy(gameObject);
			}
			else
			{
				StartCoroutine(resetColor());
			}
		}
	}
	public IEnumerator resetColor()
	{
		Spr.color = new Vector4(1.0f, 0.25f, 0.25f, 1.0f);
		yield return new WaitForSeconds(0.125f);
		Spr.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
	}

}
