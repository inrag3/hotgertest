using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class WallSlider : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody.velocity = new Vector2(-2f, 0);
    }
    
    private void Update()
    {
        if (_rigidbody.transform.position.x < -20f)
            _rigidbody.transform.position = new Vector2(21f, 0);
    }
}