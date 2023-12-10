using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float bulletsPerMinute;
    private float _delay;
    private float _currentTime;
    private bool _allowFire = true;
    
    [SerializeField] private ParticleSystem gunVFX;
    private AudioSource _audioSource;

    [SerializeField] private float damage;
    [SerializeField] private float maxDistance;
    
    private Camera _camera;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _delay = 60 / bulletsPerMinute;
        
        _camera = Camera.main;
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
            _currentTime += Time.fixedDeltaTime;
            if (_currentTime > _delay)
            {
                _allowFire = true;
                _currentTime = 0f;
            }
        }
    }

    private void Shooting()
    {
        if(gunVFX)gunVFX.Play();
        if(_audioSource) _audioSource.Play();
        
        var width = Screen.width / 2;
        var height = Screen.height / 2;
        Vector3 screenPoint = new Vector3(width, height, 0);
        
        Ray ray = _camera.ScreenPointToRay(screenPoint);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<EnemyHP>().TakeDamage(damage);
            }
        }
    }
}
