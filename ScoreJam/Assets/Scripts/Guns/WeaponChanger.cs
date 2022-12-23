using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private ScorePoints scp;
    [SerializeField ] private GameObject[] weapons;
    private int _weaponInOrder;
    private int _nextScoreGoal = 500, _goalMultiplier;
    private void Update()
    {
        if (scp.score >= _nextScoreGoal)
        {
            weapons[_weaponInOrder].gameObject.SetActive(false);
            _weaponInOrder++;
            if (_weaponInOrder == weapons.Length)
            {
                _weaponInOrder = 0;
            }
            weapons[_weaponInOrder].gameObject.SetActive(true);
            _nextScoreGoal += 500 + (500 * _goalMultiplier++);
        }
    }
}
