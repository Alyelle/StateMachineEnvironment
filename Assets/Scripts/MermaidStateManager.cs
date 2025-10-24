using UnityEngine;
using System.Collections;
using static UnityEditor.PlayerSettings;

public class MermaidStateManager : MonoBehaviour
{
    [SerializeField] public Animator anim;

    private float speed;
    private Vector2 moveDir;
    private bool moving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        speed = 2f;
        moving = false;

        StartCoroutine(SwimAround());

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 pos = transform.position;
            Vector3 scale = transform.localScale;

            //scaling
            if (moveDir.x > 0)
            {
                scale.x = -1;
            }
            else if (moveDir.x < 0)
            {
                scale.x = 1;
            }
            transform.localScale = scale;

            //positioning
            transform.Translate(moveDir * speed * Time.deltaTime);
            pos.x = Mathf.Clamp(pos.x, -7f, 7f);
            pos.y = Mathf.Clamp(pos.y, -4f, 4f);
            transform.position = pos;
        }
    }

    IEnumerator SwimAround()
    {
        while (true)
        {
            float swimTime = Random.Range(3f, 9f);
            moving = true;
            moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            anim.SetBool("swimming", true);

            yield return new WaitForSeconds(swimTime);

            float idleTime = Random.Range(3f, 5f);
            moving = false;
            anim.SetBool("swimming", false);

            yield return new WaitForSeconds(idleTime);
        }
        
    }
}
