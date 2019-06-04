using UnityEngine;

public class ChangeFace : MonoBehaviour
{

    [SerializeField] private Material goodFace = default;

    [SerializeField] private Material evilFace = default;

    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

//    // Update is called once per frame
//    void Update()
//    {
//        
//    }

    public void MakeEvil()
    {
        _meshRenderer.material = evilFace;
    }

    public void MakeGood()
    {
        _meshRenderer.material = goodFace;
    }
}
