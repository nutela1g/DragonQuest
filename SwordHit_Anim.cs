using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit_Anim : MonoBehaviour
{
    public Animator animator;
    public GameObject hrac;
    public GameObject mec;
    public GameObject mec2;
    public Vector2 poz_hrac;
    public Vector3 poz_mec;
    public Collider2D Collider1;
    public Collider2D Collider2;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;
    public int Smer;
    public float time;
    private float time2;
    private float time1;
    void Start()
    {
        spriteRenderer = mec.GetComponent<SpriteRenderer>();
        spriteRenderer2 = mec2.GetComponent<SpriteRenderer>();
        mec.transform.rotation = new Quaternion(0, 0, 0, 0);
        //Collider1 = HitBox.GetComponent<Collider2D>();
        //Collider2 = HitBox.GetComponent<Collider2D>();
        Collider1.enabled = false;
        Collider2.enabled = false;
    }

    void Update()
    {
        time = time + Time.deltaTime;
        time1 = time1 + Time.deltaTime;
        time2 = time2 + Time.deltaTime;
        print(time2);
        if (time2 < 1f)
        {
            StartCoroutine(waiter());
            mec.gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (time2 > 1f)
        {
            mec2.gameObject.GetComponent<Renderer>().enabled = false;
            Collider1.enabled = false;
            Collider2.enabled = false;
        }
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetInteger("SwordStab", 1);
            time = 0;
            time2 = 0;
        }
        else if (time > 0.4f)
        {
            animator.SetInteger("SwordStab", 0);
            animator.SetInteger("SwordlongCut", 0);
            time = 0;
        }
        time2 = time2 + Time.deltaTime;
        if (Smer == 1 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)))
        {
            Collider1.enabled = true;
            time1 = 0;
        }
        else if (Smer == 1 && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            Collider2.enabled = true;
            time1 = 0;
        }
        else if (time1 > 0.4f && Smer == 1)
        {
            Collider2.enabled = true;
            time1 = 0;
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        mec2.gameObject.GetComponent<Renderer>().enabled = true;
        Smer = 1;
        mec.gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        mec2.gameObject.GetComponent<Renderer>().enabled = false;
        Smer = 0;
        Collider1.enabled = false;
        Collider2.enabled = false;
        yield return new WaitForSecondsRealtime(0.6f);
        mec.gameObject.GetComponent<Renderer>().enabled = true;
    }
}
