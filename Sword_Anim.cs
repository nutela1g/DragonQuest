using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Sword_Anim : MonoBehaviour
{
    public Animator animator;
    public GameObject hrac;
    public GameObject mec;
    public GameObject mec2;
    private Vector2 poz_hrac;
    private Vector3 poz_mec;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;
    private float time2;
    private int KdeMec;
    void Start()
    {
        spriteRenderer = mec.GetComponent<SpriteRenderer>();
        poz_hrac = hrac.transform.position;
        mec.transform.position = poz_hrac;
    }

    void Update()
    {
        poz_hrac = hrac.transform.position;
        mec.transform.position = new Vector3(poz_hrac.x, poz_hrac.y, 1f);
        spriteRenderer.transform.localScale = new Vector3(0f, 0f, 0f);
        time2 = time2 + Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || time2 > 0.1f)
            spriteRenderer.transform.localScale = new Vector3(3f, 3f, 3f);
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = false;
            time2 = 0;
            mec.transform.position = new Vector3(poz_hrac.x, poz_hrac.y, -1f);
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            time2 = 0;
            mec.transform.position = new Vector3(poz_hrac.x, poz_hrac.y + 0.2f, 1f);
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = false;
            time2 = 0;
            mec.transform.position = new Vector3(poz_hrac.x, poz_hrac.y,- 1f);
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (Input.GetKey(KeyCode.A)) //left
        {
            /*spriteRenderer.flipY = true;
            spriteRenderer.flipX = true;
            time2 = 0;
            mec.transform.position = new Vector3(poz_hrac.x - 0.2f, poz_hrac.y - 0.18f, 1f);*/
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }

        else if (Input.GetKey(KeyCode.S)) //down
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            time2 = 0;
            mec.transform.position = new Vector3(poz_hrac.x, poz_hrac.y + 0.2f, 1f);
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            /*spriteRenderer.flipX = false;
            spriteRenderer.flipY = true;
            time2 = 0;
            mec.transform.position = new Vector3(poz_hrac.x + 0.17f, poz_hrac.y - 0.28f + bobbing, - 1f);*/
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
        else if(time2 > 0.1f)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            mec.transform.position = new Vector3(poz_hrac.x, poz_hrac.y + 0.2f, 1f);
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
    IEnumerator waiter()
    {
        mec.gameObject.GetComponent<Renderer>().enabled = false;
        if (KdeMec == 0)
        {
            mec2.transform.position = new Vector3(poz_hrac.x - 0.4f, poz_hrac.y - 0.4f, -1);
            mec2.transform.rotation = Quaternion.Euler(0, 0, 45);
            mec2.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (KdeMec == 1)
        {
            mec2.transform.position = new Vector3(poz_hrac.x, poz_hrac.y, 1);
            mec2.transform.rotation = Quaternion.Euler(0, 0, 225);
            mec2.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (KdeMec == 2)
        {
            mec2.transform.position = new Vector3(poz_hrac.x + 0.1f, poz_hrac.y - 0.15f, -1);
            mec2.transform.rotation = Quaternion.Euler(0, 0, 225);
            mec2.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (KdeMec == 3)
        {
            spriteRenderer2.flipX = true;
            mec2.transform.position = new Vector3(poz_hrac.x - 0.2f, poz_hrac.y - 0.15f, -1);
            mec2.transform.rotation = Quaternion.Euler(0, 0, -40);
            mec2.gameObject.GetComponent<Renderer>().enabled = true;
        }
        yield return new WaitForSecondsRealtime(1);
    }
}
