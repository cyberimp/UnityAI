using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiIdle : MonoBehaviour
{
    private Transform _target = null;

    private Rigidbody _rigidbody = null;
    [SerializeField] private float pauseFrom=0.2f;
    [SerializeField] private float pauseTo=2.0f;
    
//    // Start is called before the first frame update
//    private void Start()
//    {
//    }

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.zero;

        var warFace = GetComponentInChildren<ChangeFace>();
        if(warFace)
            warFace.MakeGood();
        FindTarget();
    }

    private void FindTarget()
    {
        _target = null;
        var hit = new Collider[20];
        var size = Physics.OverlapSphereNonAlloc(transform.position, 10, hit);
        if (size <= 0)
        {
            Debug.LogError("no waypoints set");
            return;
        }

        while (!_target)
        {
            var obj = hit[Random.Range(0, size)].gameObject;
            _target = obj.CompareTag("Finish") ? obj.transform : null;
        }
        //^^^^here is null check        
        // ReSharper disable once PossibleNullReferenceException
        _rigidbody.rotation = Quaternion.LookRotation(_target.position - transform.position, Vector3.up);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddRelativeForce(Vector3.forward*50.0f);
    }

//    // Update is called once per frame
//    void Update()
//    {
//        
//    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.transform != _target)
            yield break;

        _rigidbody.velocity = Vector3.zero;
        
        yield return new WaitForSeconds(Random.Range(pauseFrom,pauseTo));
        
        //untagging for exclusion from search
        other.tag = "Untagged";
        FindTarget();
        other.tag = "Finish";
    }
}
