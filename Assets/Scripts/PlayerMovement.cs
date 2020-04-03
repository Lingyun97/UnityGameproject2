using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int jumpHeight=5;
    public float moveSpeed= 3f;
    public int maxJump=2;
    public bool isAlive;
    public Animator animator;
    public Score score;

    private int numJumps;
    private Rigidbody2D body2D;
    private bool faceright;
    private bool getkey;
    public AudioSource source;
    public Button restart;

    void Awake()
    {
        isAlive = true;
        getkey = false;
    }

    void Start()
    {
        animator.SetBool("Isjump", false);
        numJumps = 0;
        body2D = GetComponent<Rigidbody2D>();
        faceright = true;
    }


    void Update()
    {
        if (body2D.position.y<-4.5f)
        {
            isAlive = false;
        }
        //		GUI.Box (Rect (10, 10, 150, 30), coins.ToString ());
        if (isAlive == true)
        {
            var val = Input.GetAxis("Horizontal");
            if (val > 0)
            {
                if (!faceright)
                {
                  transform.localScale = new Vector2(2, transform.localScale.y);
                    faceright = true;
                }
                animator.SetFloat("speed", Mathf.Abs(moveSpeed));
            }
            else if(val<0){
                animator.SetFloat("speed", Mathf.Abs(moveSpeed));
                transform.localScale = new Vector2(-2, transform.localScale.y);
                faceright = false;
            }
            else{
                animator.SetFloat("speed", 0);
            }
            body2D.velocity = new Vector2(moveSpeed * val, body2D.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) && CanJump())
            {
                float x = GetComponent<Rigidbody2D>().velocity.x;
                if (numJumps > 0)
                {
                    animator.SetBool("Isjump2", true);
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(x, jumpHeight);
                animator.SetBool("Isjump", true);
                numJumps++;
            }

        }
        else
        {
            Debug.Log("Died");
            SceneManager.LoadScene("Gameover");
        }



    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Isjump", false);
            animator.SetBool("Isjump2", false);
            numJumps = 0;
        }
        if (coll.gameObject.tag == "Enmies")
        {
            if (isAlive)
            {
                isAlive = false;
            }
        }
        if (coll.gameObject.tag == "Magictile")
        {
            StartCoroutine(ShowAndHide(coll.gameObject, 1.0f));
            animator.SetBool("Isjump2", false);
            animator.SetBool("Isjump", false);
            numJumps = 0;
        }


    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if(collider2d.gameObject.tag == "Melon")
        {
            Destroy(collider2d.gameObject);
            score.SetScore();
        }
        if (collider2d.gameObject.tag == "Key")
        {
            Destroy(collider2d.gameObject);
            getkey = true;
        }
        if (collider2d.gameObject.tag == "Flag")
        {
            if (getkey)
            {
                Destroy(collider2d.gameObject);
                getkey = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (collider2d.gameObject.tag == "final")
        {
            if (getkey)
            {
                score.win();
                restart.gameObject.SetActive(true);
            }
        }
        source.Play();
    }


    bool CanJump()
    {
        return numJumps < maxJump;
    }

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(false);
        yield return new WaitForSeconds(delay);
        go.SetActive(true);
    }

}
