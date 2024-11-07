using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Anim : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //up
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
            animator.SetInteger("anim_int", 5);
            this.gameObject.GetComponent<Animator>().enabled = true;
        }

        else if (Input.GetKey(KeyCode.A)) //left
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
            animator.SetInteger("anim_int", 2);
            this.gameObject.GetComponent<Animator>().enabled = true;
        }
        else if (Input.GetKey(KeyCode.S)) //down
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
            animator.SetInteger("anim_int", 4);
            this.gameObject.GetComponent<Animator>().enabled = true;
        }

        else if (Input.GetKey(KeyCode.D)) //right
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
            animator.SetInteger("anim_int", 3);
            this.gameObject.GetComponent<Animator>().enabled = true;
        }
        else //idle 
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
            animator.SetInteger("anim_int", 0);
            this.gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
