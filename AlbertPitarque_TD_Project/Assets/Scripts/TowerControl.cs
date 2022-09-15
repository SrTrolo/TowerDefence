using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerControl : MonoBehaviour
{
    public int[] whitelistTiles;
    public int price, upgradePrice;

    public GameManager manager;
    private bool active;
    public enum towerType { ShootTower, SlowTower }
    public towerType type;

    public LayerMask enemyDetect;
    [Header("Shoot Type")]
    public float fireRate;
    private float countRate;
    public float damage;
    private GameObject currentEnemy;

    [Header("Freeze Type")]
    public List<Collider2D> allEnemies;
    public float percentSpeed;

    public GameObject Panel, Area;
    public GameObject Tfire, Tdamage, TSpeed, Tupgrade;

    public List<GameObject> allSounds;
    void Start()
    {

    }
    public void InitTower(GameManager _mng)
    {
        manager = _mng;
        active = true;
        Area.SetActive(false);
    }


    void Update()
    {
        
        
        if (active == true)
        {
            Tupgrade.GetComponent<TextMesh>().text = upgradePrice.ToString() + ("$");
            switch (type)
            {
                case towerType.ShootTower:
                    Tfire.GetComponent<TextMesh>().text = fireRate.ToString();
                    Tdamage.GetComponent<TextMesh>().text = damage.ToString();
                    
                    ShootTowerUpdate();
                    break;
                case towerType.SlowTower:
                    TSpeed.GetComponent<TextMesh>().text = percentSpeed.ToString();
                    SlowTowerUpdate();
                    break;
            }
        }

    }
    private void ShootTowerUpdate()
    {
        if (currentEnemy != null)
        {
            countRate += Time.deltaTime;
            if (countRate > fireRate)
            {
                //disparo y sonido de disparo
                countRate = 0;
                currentEnemy.GetComponent<EnemyControl>().GetDamage((int)damage);
            }
            if (Vector2.Distance(transform.position, currentEnemy.transform.position) > transform.GetChild(0).localScale.x / 2)
            {
                currentEnemy = null;
            }
        }
        else
        {
            Collider2D detectEnemy = Physics2D.OverlapCircle(transform.position, transform.GetChild(0).localScale.x / 2, enemyDetect);
            if (detectEnemy != null)
            {
                currentEnemy = detectEnemy.gameObject;
            }
        }
    }
    private void SlowTowerUpdate()
    {

        Collider2D[] detectEnemies = Physics2D.OverlapCircleAll(transform.position, transform.GetChild(0).localScale.x / 2, enemyDetect);
        for (int i = 0; i < detectEnemies.Length; i++)
        {
            if (allEnemies.Contains(detectEnemies[i]) == false)
            {
                allEnemies.Add(detectEnemies[i]);
            }
            detectEnemies[i].GetComponent<EnemyControl>().SetSpeed(percentSpeed);
        }

        for (int i = 0; i < allEnemies.Count; i++)
        {
            if(allEnemies[i] != null)
            {
                if (Vector2.Distance(transform.position, allEnemies[i].transform.position) > transform.GetChild(0).localScale.x / 2)
                {
                    allEnemies[i].GetComponent<EnemyControl>().ResetSpeed();
                    allEnemies.RemoveAt(i);
                }
            }
            
        }
    }
    private void OnMouseDown()
    {
        GameObject newSound = Instantiate(allSounds[0]);
        Destroy(newSound, 1);
        Panel.SetActive(!Panel.activeSelf);
        Area.SetActive(Panel.activeSelf);
    }

}
