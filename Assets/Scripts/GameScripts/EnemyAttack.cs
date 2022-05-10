using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour {
    
    private bool CanAttack = true;
    private int Cooldown = 0;
    private Animator attackAnimation;
    void Update() {
        attackAnimation = transform.Find("gfx").GetComponent<Animator>();
        if(!CanAttack) {
            Cooldown++;
            if (Cooldown == 50) {
                attackAnimation.SetBool("isAttacking", false);
            }
            if(Cooldown == 60) {
                CanAttack = true;
                Cooldown = 0;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col) {
        if(SceneManager.GetActiveScene().name != "TestScene"){return;}
        if(col.collider.tag != "Player"){return;}
        if(CanAttack) {
            col.gameObject.GetComponent<PlayerHealth>().IsAttacked(col.gameObject);
            attackAnimation.SetBool("isAttacking", true);
            CanAttack = false;
        }
    }
}
