using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject mermaidPf;
    [SerializeField] public GameObject seaweedPf;
    [SerializeField] public GameObject bassPf;

    private GameObject currentMermaid;

    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SeaweedSpawn());
        StartCoroutine(BassSpawn());
    }

    // Update is called once per frame
    void Update()   
    {
        if (currentMermaid == null)
        {
            SpawnMermaid();
        }
    }

    void SpawnMermaid()
    {
        Vector3 spawn = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), transform.position.z);
        currentMermaid = Instantiate(mermaidPf, spawn, Quaternion.identity);
    }

    IEnumerator SeaweedSpawn()
    {
        float spawnTimer = Random.Range(2f, 10f);

        yield return new WaitForSeconds(spawnTimer);
        Instantiate(seaweedPf);

    }

    IEnumerator BassSpawn()
    {
        float spawnTimer = Random.Range(5f, 15f);

        yield return new WaitForSeconds(spawnTimer);
        Instantiate(bassPf);
    }


}
