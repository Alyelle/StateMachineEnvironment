using UnityEngine;
using System.Collections;

public class BassStateManager : MonoBehaviour
{
    [SerializeField] public Animator anim;

    private bool swimming;
    private Vector2 moveDir;
    private bool up;

    private Coroutine swimRoutine;
    private Coroutine floatRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swimming= false;
        up = false;
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
                scale.x = 1;
            }
            else if (moveDir.x < 0)
            {
                scale.x = -1;
            }
            transform.localScale = scale;

            transform.Translate((Vector3)(moveDir * 1 * Time.deltaTime));

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -7f, 7f);

            transform.position = pos;
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

        StopCoroutine(SwimAround());
        swimming = false;
        StartCoroutine(FloatUpDown());

    }
    IEnumerator SwimAround()
    {
        while (true)
        {
            float swimTime = Random.Range(4f, 7f);
            swimming = true;
            moveDir = new Vector2(Random.Range(-1f, 1f), transform.position.y);

            yield return new WaitForSeconds(swimTime);
        }
    }

    IEnumerator FloatUpDown()
    {
        while (true)
        {
            float timer = 1f;
            float speed = 0.5f;

            Vector3 pos = transform.position;

            up = true;
            pos.y += speed * Time.deltaTime;
            yield return new WaitForSeconds(timer);

            up = false;
            pos.y -= speed* Time.deltaTime;
            yield return new WaitForSeconds(timer);
        }
    }
}
