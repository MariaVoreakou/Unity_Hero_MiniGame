using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameState : MonoBehaviour {

    public bool gameover = false;
    bool playerturn=true;
    int level=1;
    double xp = 0; 
    //if true player's turn else monster's

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameover == true)
        {
            Application.Quit();

        }
    }

    public void makeTurn() {
        if (gameover) {
            return;
        }
        if (playerturn == true)
        {
            Debug.Log("It's the player's turn \n");
            GameObject.FindGameObjectWithTag("Player").GetComponent<KnightScript>().Attack();
        }
        else
        {
            Debug.Log("It's the monster's turn \n");
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterScript>().Attack();
        }

        if (playerturn == true)
        {
            playerturn = false;
        }
        else {
            playerturn = true;
        }

        Debug.Log("player health:"+ GameObject.FindGameObjectWithTag("Player").GetComponent<KnightScript>().health +"\n");
        Debug.Log("enemy health:" + GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterScript>().health + "\n");

        Debug.Log("------------Next Turn------------- \n");

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<KnightScript>().health <= 0)
        {
            gameover = true;
            Debug.Log("GAME OVER MAN!\n");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().GetClip("Dead");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().wrapMode = WrapMode.Once;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>().Play();
        }
        if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterScript>().health <= 0)
        {
            nextLevel();
            gameover = true;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().clip = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().GetClip("Dead");
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().wrapMode = WrapMode.Once;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animation>().Play();
        }

    }

    public void nextLevel() {
        Debug.Log("Congrats! You beat level "+level+"! You gained "+ GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterScript>().xp + "xp! \n");
        this.xp+= GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterScript>().xp;
        Debug.Log("Total xp gained "+xp);
        level++;
    }
}
