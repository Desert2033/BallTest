using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private Transform _textureCubeTransform;

    [SerializeField] private ParticleSystem _destroyCoin;
    
    private void Update()
    {
        _textureCubeTransform.Rotate(0f, 0.5f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinEvents.TakeCoin?.Invoke();
        _destroyCoin.transform.position = transform.position;
        _destroyCoin.Play();
        Destroy(gameObject);
    }

}
