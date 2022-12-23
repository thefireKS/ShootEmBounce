using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject[] gunDots;
    
    [SerializeField] private GameObject ammo;
    [SerializeField] private float fireForce;
    [SerializeField] private float bulletsPerMinute;

    private float _delay;
    
    [SerializeField] private ParticleSystem particleSystem;
    private float currentTime = 0f;
    private bool _allowFire = true;

    private void Start()
    {
        _delay = 1/(bulletsPerMinute*60);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && _allowFire)
        {
            Shooting();
            _allowFire = false;
        }
    }

    private void FixedUpdate()
    {
        CheckDelay();
    }

    private void CheckDelay()
    {
        if (_allowFire == false)
        {
            currentTime += Time.fixedDeltaTime;
            if (currentTime > _delay)
            {
                _allowFire = true;
                currentTime = 0f;
            }
        }
    }

    private void Shooting()
    {
        particleSystem.Play();
        foreach (var gunDot in gunDots)
        {
            Vector3 spawnPoint = gunDot.transform.position;
            Quaternion spawnRoot = gunDot.transform.rotation;
            GameObject firedAmmo = Instantiate(ammo, spawnPoint, spawnRoot);
            Rigidbody firedAmmoRb = firedAmmo.GetComponent<Rigidbody>();
            firedAmmoRb.AddForce(firedAmmo.transform.forward * fireForce, ForceMode.Impulse);
        }
    }
}
