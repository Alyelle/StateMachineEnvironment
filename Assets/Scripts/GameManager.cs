using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject mermaid;
    [SerializeField] public GameObject seaweed;
    [SerializeField] public GameObject bass;

    private void Awake()
    {
       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 spawn = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), transform.position.z);
        Instantiate(mermaid, spawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (mermaid == null)
        {
            Vector3 spawn = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), transform.position.z);
            Instantiate(mermaid, spawn, Quaternion.identity);
        }
    }


}
