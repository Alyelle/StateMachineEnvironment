using UnityEngine;
using System.Collections;

public class SeaweedStateManager : MonoBehaviour
{
    [SerializeField] public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(-7f, 7f);
        transform.position = pos;

        StartCoroutine(RandomTimer());
    }

    // Update is called once per frame
    void Update() { 
 

    }

    IEnumerator RandomTimer()
    {
        float growTimer = Random.Range(3f, 12f);

        yield return new WaitForSeconds(growTimer);

        anim.SetBool("grown", true);
    }
}
