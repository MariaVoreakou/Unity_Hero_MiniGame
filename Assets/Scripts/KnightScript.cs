using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour {
    public int health = 100;
    public int armor = 30;
    public int damage = 10;

    public void setHealth(int health)
    {
        this.health = health;
    }
    public void setArmor(int armor)
    {
        this.armor = armor;
    }
    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    // Use this for initialization
    void Start () {
        
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().wrapMode = WrapMode.Loop;
	}
	// Update is called once per frame
	void Update () {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().isPlaying && !GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>().gameover) {

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().GetClip("Wait");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().wrapMode = WrapMode.Loop;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().Play();
        }
	}

    public void TakeDamage(int damage)
    {
        int localDamage = damage - ((int)(armor * 0.3f));
        if (localDamage <0)
        {
            localDamage = 0;
        }
       
        Debug.Log("player takes " + localDamage + " damage!!!!\n");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().wrapMode = WrapMode.Once;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().GetClip("Damage");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().Play();

        health -= localDamage;
        
    }
    public void Attack()
    {
        Debug.Log("player attacks!!!!\n");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().wrapMode = WrapMode.Once;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().GetClip("Attack");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().Play();
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterScript>().TakeDamage(damage);
    }




}
