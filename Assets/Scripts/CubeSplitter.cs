using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private int _particlesMinimalNumber = 2;
    [SerializeField] private int _particlesMaximalNumber = 4;
    [SerializeField] private Cube _particlePrefab;
    [SerializeField] private float _particleScale = 0.5f;
    [SerializeField] CubeDetonator _cubeDetonator;

    private int _chanceValue;
    private int _randomValue;
    private int _splitValue;
    private int _particlesNumber;
    private Color _particleColor;
    private Cube _cube;

    private void Start()
    {
        _cube = GetComponent<Cube>();
        _chanceValue = 100;
        _splitValue = 2;
    }

    private void OnMouseDown()
    {
        TrySplit();
    }

    private void TrySplit()
    {
        _particlesNumber = Random.Range(_particlesMinimalNumber, _particlesMaximalNumber + 1);
        _randomValue = Random.Range(0, _chanceValue);
        
        if (_cube.SplitChance >= _randomValue)
        {
            for (int i = 0; i < _particlesNumber; i++)
            {
                _particleColor = Random.ColorHSV();

                Cube newParticle = Instantiate(_particlePrefab);
                newParticle.SetParameters(_particleColor, _particleScale, _cube.SplitChance / _splitValue);
            }
        }

        _cubeDetonator.Detonate();
    }
}
