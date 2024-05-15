using UnityEngine;

public class CubeDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private Collider[] _colliders = new Collider[20];

    public void Detonate()
    {
        int collidersNumber = Physics.OverlapSphereNonAlloc(transform.position, _explosionRadius / transform.localScale.magnitude, _colliders);

        for (int i = 0; i < collidersNumber; i++)
        {
            if (_colliders[i].TryGetComponent(out Rigidbody rigidBody))
            {
                rigidBody.AddExplosionForce(_explosionForce / transform.localScale.magnitude, transform.position, _explosionRadius / transform.localScale.magnitude);
            }
        }
    }
}
