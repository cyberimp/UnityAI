using UnityEngine;

public class WaypointGenerator : MonoBehaviour
{
    [SerializeField] private GameObject waypointPrefab = default; 
    [SerializeField] private AiIdle npc1 = default; 
    [SerializeField] private AiIdle npc2 = default; 
    
    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                Instantiate(waypointPrefab, new Vector3(i * 2 + 1, 1.23f, j * 2 + 1), Quaternion.identity, transform);
                Instantiate(waypointPrefab, new Vector3(-i * 2 - 1, 1.23f, j * 2 + 1), Quaternion.identity, transform);
                
            }
        }

        npc1.enabled = true;
        npc2.enabled = true;
    }

//    // Update is called once per frame
//    void Update()
//    {
//        
//    }
}
