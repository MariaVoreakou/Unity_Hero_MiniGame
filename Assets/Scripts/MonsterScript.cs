using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

    public int health = 40;
    public int damage = 5;
    public int xp = 5;

    public void setHealth(int health)
    {
        this.health = health;
    }
    public void setXp(int xp)
    {
        this.xp = xp;
    }
    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    // Use this for initialization
    void Start()
    {
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().wrapMode = WrapMode.Loop;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().isPlaying && !GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>().gameover)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().GetClip("Wait");
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().wrapMode = WrapMode.Loop;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().Play();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("enemy takes " + damage + " damage!!!! \n");
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().wrapMode = WrapMode.Once;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().GetClip("Damage");
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().Play();
        health -= damage;
    }
    public void Attack()
    {
        Debug.Log("enemy attacks!!!! \n");
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().wrapMode = WrapMode.Once;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().GetClip("Attack");
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().Play();
        GameObject.FindGameObjectWithTag("Player").GetComponent<KnightScript>().TakeDamage(damage);
    }
}
