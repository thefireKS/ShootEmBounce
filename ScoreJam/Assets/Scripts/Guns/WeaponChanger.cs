using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private ScorePoints scp;
    [SerializeField ] private GameObject[] weapons;
    private int _weaponInOrder;
    private int nextScoreGoal = 500, goalMultiplier = 0;
    private void Update()
    {
        Debug.Log(nextScoreGoal);
        if (scp.score >= nextScoreGoal)
        {
            weapons[_weaponInOrder].gameObject.SetActive(false);
            _weaponInOrder++;
            if (_weaponInOrder == weapons.Length)
            {
                _weaponInOrder = 0;
            }
            weapons[_weaponInOrder].gameObject.SetActive(true);
            nextScoreGoal += 500 * goalMultiplier++;
        }
    }
}
