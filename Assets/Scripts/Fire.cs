using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject block;
    public Animator animator;
    public bool fired = false;

    void OnCollisionEnter2D(Collision2D coll)
    {

            if (!fired){
             animator.SetBool("Isfired", true);
            StartCoroutine(ShowAndHide(30f));
            fired = true;
        }
        
    }

    IEnumerator ShowAndHide(float delay)
    {
        block.SetActive(false);
        yield return new WaitForSeconds(delay);
        block.SetActive(true);
        animator.SetBool("Isfired", false);
    }
}
