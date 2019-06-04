using UnityEngine;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] private int maxHp = 10;
    [SerializeField] private Text text = default;

    private int _hp;

    private Rigidbody _rigidbody;

    private CapsuleCollider _capsuleCollider;

    // Start is called before the first frame update
    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _hp = maxHp;
        _rigidbody = GetComponent<Rigidbody>();
    }

//    // Update is called once per frame
//    void Update()
//    {
//        
//    }

    private void Die()
    {
        text.text = "HP: DEAD!";
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.constraints = RigidbodyConstraints.None;
        Destroy(_capsuleCollider,0.5f);
        Destroy(gameObject, 0.7f);
    }

    public bool Hurt(int value)
    {
        _hp -= value;
        text.text = "HP: " + _hp;
        if (_hp >= 0) return false;
        
        Die();
        return true;
    }
}
