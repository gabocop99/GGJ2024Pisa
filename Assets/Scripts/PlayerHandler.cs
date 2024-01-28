using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private int _playerLifePoints;
    public bool IsDead()
    {
        return _playerLifePoints <= 0;
    }

    public void HealthDown(){
        _playerLifePoints--;
    }


    public int GetHealth()
    {
        return _playerLifePoints;
    }

    private void Update()
    {
        if (IsDead())
        {
            SceneManager.LoadScene("scenaMorte");
        }
    }
}
