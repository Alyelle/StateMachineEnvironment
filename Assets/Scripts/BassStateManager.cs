using UnityEngine;
using System.Collections;

public class BassStateManager : MonoBehaviour
{
    [SerializeField] public Animator anim;

    private bool swimming;
    private Vector2 moveDir;
    //private bool up;
    private bool sinking;

    private Coroutine swimRoutine;
    private Coroutine floatRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swimming= false;
        sinking = false;
        //up = false;
        Vector3 pos = transform.position;

        pos.x = Random.Range(-7f, 7f);
        pos.y = Random.Range(-4f, 4f);
        transform.position = pos;

        StartCoroutine(HatchingTimer());
    }

    void Update()
    {
        if (swimming)
        {
            Vector3 scale = transform.localScale;

            if (moveDir.x > 0)
            {
                scale.x = -1;
            }
            else if (moveDir.x < 0)
            {
                scale.x = 1;
            }
            transform.localScale = scale;

            transform.Translate((Vector3)(moveDir * 1 * Time.deltaTime));

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -7f, 7f);
            pos.x = Mathf.Clamp(pos.x, -4f, 4f);

            transform.position = pos;
        }
        else if (sinking)
        {
            Vector3 pos = transform.position;

            if (pos.y >= -5f)
            {
                pos.y -= 0.3f * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator HatchingTimer()
    {
        float hatchTimer = Random.Range(5f, 15f);

        yield return new WaitForSeconds(hatchTimer);

        anim.SetBool("hatched", true);

        StartCoroutine(BassTimer());
        swimRoutine = StartCoroutine(SwimAround());
    }

    IEnumerator BassTimer()
    {
        float growTimer = Random.Range(10f, 12f);

        yield return new WaitForSeconds(growTimer);

        anim.SetBool("guitar", true);

        StopCoroutine(swimRoutine);
        swimming = false;
        sinking = true ;

    }
    IEnumerator SwimAround()
    {
        while (true)
        {
            float swimTime = Random.Range(0.1f, 4f);
            swimming = true;
            moveDir = new Vector2(Random.Range(-1f, 1f), 0f);

            yield return new WaitForSeconds(swimTime);
        }
    }
}
