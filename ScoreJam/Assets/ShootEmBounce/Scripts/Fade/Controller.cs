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
            MenuManager.MenuChanged += OnMenuChanged;
        }

        private void OnDisable()
        {
            MenuManager.MenuChanged -= OnMenuChanged;
        }

        private void Awake()
        {
            _fadeAnimator = GameObject.Find("Fade").GetComponent<Animator>();
        }
        
        /// <summary>
        /// Start fade out animation
        /// </summary>
        public void StartFade()
        {
            _fadeAnimator.Play("LoadAnim");
        }

        private void OnMenuChanged()
        {
            StartFade();
        }
    }
}
