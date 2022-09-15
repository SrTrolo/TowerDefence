using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonControl : MonoBehaviour
{
    public GameObject Tower, Manager;
    TowerControl tower;
    GameManager manager;
    public List<GameObject> allSounds;
    void Start()
    {
        tower = Tower.GetComponent<TowerControl>();
        
    }


    void Update()
    {

    }
    private void OnMouseDown()
    {
        if(tower.manager.money - tower.upgradePrice >= 0)
        {
            GameObject newSound = Instantiate(allSounds[0]);
            Destroy(newSound, 1);
            if (tower.type == TowerControl.towerType.ShootTower && tower.fireRate >= 0)
            {
                if (tower.fireRate > 0)
                {
                    tower.manager.money -= tower.upgradePrice;
                    tower.damage = tower.damage * 1.5f;
                    tower.upgradePrice *= 2;
                    tower.fireRate *= 0.8f;
                    
                }
                else
                {
                    tower.fireRate = 0.1f;
                }

            }
            if (tower.type == TowerControl.towerType.SlowTower && tower.percentSpeed <= 100)
            {

                if (tower.percentSpeed < 100)
                {
                    tower.manager.money -= tower.upgradePrice;
                    tower.percentSpeed += 10;
                    tower.upgradePrice *= 2;

                }

                if (tower.percentSpeed >= 100)
                {
                    tower.percentSpeed = 99;
                }
            }
        }
        
    }
}
