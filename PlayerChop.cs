using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChop : MonoBehaviour
// melee logic to chop chop on the trr yt tutorial on melee stuff
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f; //hit box of the chop chop
    public LayerMask treeLayer;

    public float chopRate = 2f;
    float nextChopTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextChopTime){
            if(Input.GetKeyDown(KeyCode.Space)){
                Chop();
                nextChopTime = Time.time + 1f / chopRate;
            } // stops you from spamming the chop chop
        }
    }


    void Chop(){
        //Play Chop animation ( used ladder climb animation because it was the last animation on my sprite)
        animator.SetTrigger("Chop");

        // find tree
        Collider2D[] hitTrees = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, treeLayer);
        // break chop tree

        foreach(Collider2D enemy in hitTrees){
            enemy.GetComponent<Tree>().TakeDamage(20);
        }
    }

    void OnDrawGizmosSelected(){
// this let me see my hit box on unity scene
        if(attackPoint == null){
            return;
            }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
