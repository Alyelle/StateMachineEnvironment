using UnityEngine;
using System.Collections;

public class SeaweedStateManager : MonoBehaviour
{
    [SerializeField] public Animator anim;

    public Vector3 defPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Vector3 pos = transform.position;

        pos.x = Random.Range(-7f, 7f);
        transform.position = pos;

        StartCoroutine(GrowingTimer());
    }

    // Update is called once per frame
    void Update() { 
        if (anim.GetBool("overgrown"))
        {

            Vector3 pos = transform.position;

            if (pos.y <= 5f)
            {
                pos.y += 0.3f * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator GrowingTimer()
    {
        float growTimer = Random.Range(3f, 12f);

        yield return new WaitForSeconds(growTimer);

        anim.SetBool("grown", true);

        StartCoroutine(WeedTimer());
    }

    IEnumerator WeedTimer()
    {
        float growTimer = Random.Range(7f, 10f);

        yield return new WaitForSeconds(growTimer);

        anim.SetBool("overgrown", true);
       
    }
}
