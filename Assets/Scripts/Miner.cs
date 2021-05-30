using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Miner : Enemy {

	public float walkDistance;

	public GameObject Platform;
	private bool walk;
	private bool attack = false;

	private float speed1 =100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {

		base.Update();

		anim.SetBool("Walk", walk);
		anim.SetBool("Attack", attack);

		if(Mathf.Abs(targetDistance) < walkDistance)
		{
			walk = true;
		}

		if(Mathf.Abs(targetDistance) < attackDistance)
		{
			attack = true;
			walk = false;
		}
		
	}

	private void FixedUpdate()
	{
		if(walk && !attack)
		{
			if(targetDistance < 0)
			{
				rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
				if (!facingRight)
				{
					Flip();
				}
			}
			else
			{
				rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
				if (facingRight)
				{
					Flip();
				}
			}
		}
	}
	public override void TookDamage(int damage)
	{
		health -= damage;
		if(health <= 0)
		{
			
			Instantiate(coin, transform.position, transform.rotation);
			Instantiate(coin, transform.position, transform.rotation);
			Instantiate(coin, transform.position, transform.rotation);
			Instantiate(deathAnimation, transform.position, transform.rotation);

			gameObject.SetActive(false);
			Platform.transform.Translate(Vector3.left * speed1 * Time.deltaTime);
			
				
		}
		else
		{
			StartCoroutine(TookDamageCoRoutine());
		}
	}


	public void ResetAttack()
	{
		attack = false;
	}

	IEnumerator TookDamageCoRoutine()
	{
		sprite.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		sprite.color = Color.white;
	}

	
}
