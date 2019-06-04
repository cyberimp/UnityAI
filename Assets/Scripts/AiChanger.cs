using UnityEngine;

[RequireComponent(typeof(AiIdle),typeof(AiAggressive))]
public class AiChanger : MonoBehaviour
{

    private AiIdle _idle;
    private AiAggressive _aggressive;
    // Start is called before the first frame update
    private void Start()
    {
        _idle = GetComponent<AiIdle>();
        _aggressive = GetComponent<AiAggressive>();
    }

//    // Update is called once per frame
//    void Update()
//    {
//        
//    }

    //switching AI behaviour
    public void ChangeAi()
    {
        var cur = _idle.enabled;
        _idle.enabled = !cur;
        _aggressive.enabled = cur;
    }
}
