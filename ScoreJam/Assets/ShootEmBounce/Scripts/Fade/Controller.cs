using UnityEngine;

namespace ShootEmBounce.Scripts.Fade
{
    public class Controller : MonoBehaviour
    {
        /// <summary>
        /// Fade animator
        /// </summary>
        private Animator _fadeAnimator;

        private void OnEnable()
        {
            MenuManager.menuChanged += OnMenuChanged;
        }

        private void OnDisable()
        {
            MenuManager.menuChanged -= OnMenuChanged;
        }

        private void Awake()
        {
            _fadeAnimator = GameObject.Find("Fade").GetComponent<Animator>();
        }
        
        /// <summary>
        /// Start fade out animation
        /// </summary>
        private void StartFade()
        {
            Debug.Log("Fade");
            _fadeAnimator.Play("LoadAnim");
        }

        private void OnMenuChanged()
        {
            StartFade();
        }
    }
}
