using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private int _playerLifePoints;

    public bool IsDead()
    {
        return _playerLifePoints <= 0;
    }

    public void HealthMeno(){
        _playerLifePoints--;
    }

    private void Update()
    {
        if (IsDead())
        {

        }
    }
}
