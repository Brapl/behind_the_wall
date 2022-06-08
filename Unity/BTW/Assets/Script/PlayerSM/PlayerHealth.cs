using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth;
    public SpriteRenderer graphics;
    public bool isInvincible = false;
    public float invincibilityFlashDelay = 0.2f;
    public float invincibilityTimeAfterHit = 3f;

	public bool died=false;

    public HealthBar healthBar;

	public static PlayerHealth instance;

	private void Awake()
	{
		if(instance!=null)
		{
			Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
			return;	
		}
		instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
			if(currentHealth<=0)
			{
				Die();
				return;
			}
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

	public void Die()
	{
		Debug.Log("Le joueur est éliminé");
		died = true;
		Player.instance.enabled = false;
		Player.instance.anim.SetTrigger("Die");
		Player.instance.rb.bodyType=RigidbodyType2D.Kinematic;
		GameOverManager.instance.OnPlayerDeath();
	}

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color (1f,1f,1f,0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color (1f,1f,1f,1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
