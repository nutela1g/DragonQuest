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
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;

    public float time;
    private float time2;
    void Start()
    {
        spriteRenderer = mec.GetComponent<SpriteRenderer>();
        spriteRenderer2 = mec2.GetComponent<SpriteRenderer>();
        mec.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void Update()
    {
        time = time + Time.deltaTime;
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
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        mec2.gameObject.GetComponent<Renderer>().enabled = true;
    }
}
