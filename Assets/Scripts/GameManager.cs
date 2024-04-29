using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vehicle car, ship, plane;

    void Awake()
    {
       car = new Car();
       ship = new Ship();
       plane = new Plane();
    }

    private void Start()
    {
        car.Go();
        ship.Go();
        plane.Go();
    }


}
