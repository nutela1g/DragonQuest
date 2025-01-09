using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileTrue : MonoBehaviour
{
    public GameObject Ruka;
    public GameObject mec2;
    public GameObject hrac;
    public int KdeMec;
    public float time2;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = mec2.GetComponent<SpriteRenderer>();
    }

    void NejakaMecFunkcia()
    {
        switch (KdeMec)
        {
            case 0:
                spriteRenderer.flipX = false;
                Ruka.transform.position = new Vector3(hrac.transform.position.x - 0.2f, hrac.transform.position.y - 0.5f, -1);
                Ruka.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;

            case 1:
                spriteRenderer.flipX = true;
                Ruka.transform.position = new Vector3(hrac.transform.position.x + 0.13f, hrac.transform.position.y + 0.2f, 1);
                Ruka.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;

            case 2:
                spriteRenderer.flipX = false;
                Ruka.transform.position = new Vector3(hrac.transform.position.x + 0.15f, hrac.transform.position.y - 0.2f, -1);
                Ruka.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case 3:
                spriteRenderer.flipX = true;
                Ruka.transform.position = new Vector3(hrac.transform.position.x - 0.14f, hrac.transform.position.y - 0.2f, 1);
                Ruka.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            default:
                break;
        }
    }
    void Update()
    {

        time2 = time2 + Time.deltaTime;
        mec2.transform.position = new Vector3(Ruka.transform.position.x, Ruka.transform.position.y, Ruka.transform.position.z);
        mec2.transform.rotation = Ruka.transform.rotation;
        if (Input.GetKey(KeyCode.W))
        {
            KdeMec = 1;
            time2 = 0;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            KdeMec = 0;
            time2 = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            KdeMec = 3;
            time2 = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            KdeMec = 2;
            time2 = 0;
        }
        else if (time2 > 0.4f)
        {
            KdeMec = 0;
            time2 = 0;
        }
        NejakaMecFunkcia();
    }
}
