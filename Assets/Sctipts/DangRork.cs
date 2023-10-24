using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DangRork : MonoBehaviour
{
    [SerializeField] private float _shustrila;

    private Rigidbody2D _asdffff;
    private Rigidbody2D Golka => _asdffff ??= GetComponent<Rigidbody2D>();

    private float humba;
    
    private void Awake()
    {
        humba = -transform.position.y;
    }

    private void FixedUpdate()
    {
        if (Vmert)
            return;
        
        if (transform.position.y < humba)
        {
            Vmert = true;
            Destroy(gameObject);
        }
        
        var ukrrr = Golka.position + Vector2.down * Time.deltaTime * _shustrila;
        Golka.MovePosition(ukrrr);
    }

    public bool Vmert { get; set; }
}