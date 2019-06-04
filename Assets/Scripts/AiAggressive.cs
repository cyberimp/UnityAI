
using UnityEngine;

public class AiAggressive : MonoBehaviour
{
    private Transform _target;
    private Rigidbody _rigidbody;
    private ParticleSystem _gun = null;
    private PlayerHurt _player;
    private AiChanger _aiChanger;

    private void Awake()
    {
        _aiChanger = GetComponent<AiChanger>();
    }

//    void Start()
//    {
//        
//    }

    private void OnEnable()
    {
        var obj = GameObject.Find("NPC2");
        if (!obj)
        {
            _aiChanger.ChangeAi();
            return;
        }
        _target = obj.transform;

        _player = _target.gameObject.GetComponent<PlayerHurt>();

        var warFace = GetComponentInChildren<ChangeFace>();
        if(warFace)
            warFace.MakeEvil();
        _gun = GetComponentInChildren<ParticleSystem>();

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.zero;
    }

//    // Update is called once per frame
//    void Update()
//    {
//        
//    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.zero;
        if (_gun.isPlaying)
            return;
        var diff = _target.position - transform.position;
        _rigidbody.rotation = Quaternion.LookRotation(diff, Vector3.up);
        if (diff.sqrMagnitude < 4f)
        {
            _gun.Play();
            if (_player.Hurt(1))
                _aiChanger.ChangeAi();
            return;
        }
        
        _rigidbody.AddRelativeForce(Vector3.forward*50.0f);
        
    }
}
