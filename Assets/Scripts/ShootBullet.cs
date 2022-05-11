using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab, muzzlePrefab;
	public Animator animator;

	public float bulletForce, bulletDespawnTime;
	public float flashDespawnTime, cooldown;

	private float nextFireTime = 0f;

	void Update()
	{

		animator.SetBool("IsFiring", false);

		if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFireTime)
		{
			nextFireTime = Time.time + cooldown;
			
			Shoot();
			muzzleFlash();

		}

	}

	void Shoot()
	{

		animator.SetBool("IsFiring", true);
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
		Destroy(bullet, bulletDespawnTime);
		

	}

	void muzzleFlash()
    {

		GameObject flash = Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation);
		//float size = Random.Range(0.6f, 0.9f);
		//flash.transform.localScale = new Vector3(size, size, size);
		Destroy(flash, flashDespawnTime);

	}

}
