using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterManager : MonoBehaviour
{

    [SerializeField] private GameObject God; 

    public static HamsterManager instance;

    private void Awake()
    {
        instance = this;
    }
    public Criceto currentHamster;

    public void MoveCopyToGod()
    {
        Vector3 vec = new Vector3(0, 0, -250);
        currentHamster.transform.position = vec;

        currentHamster.transform.LookAt(God.transform);
    }
}
