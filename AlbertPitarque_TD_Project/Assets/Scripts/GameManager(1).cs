using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int money;
    public Text moneyText;

    public List<MapProperties> allMaps = new List<MapProperties>();
    public Sprite[] allTiles;
    public GameObject[] allEnemies;
    private List<GameObject> savedEnemies = new List<GameObject>();
    private float rateEnemies;
    private int currentEnemy, currentWave;

    public int currentMap;

    private GameObject currentTower;
    public List<GameObject> savedTowers = new List<GameObject>();


    private bool isPlaying;
    public int Lifes;

    public GameObject FinalPanel, H1, H2, H3;
    public Text finalText;
    public List<GameObject> allSounds;
    void Start()
    {
        allTiles = Resources.LoadAll<Sprite>("TileNieve");
        allEnemies = Resources.LoadAll<GameObject>("Enemy");
        MapCreator();
        MapGenerator(0);
        isPlaying = true;
        GameObject newSound = Instantiate(allSounds[2]);
        Destroy(newSound, 1);
    }


    void Update()
    {
        
        if (isPlaying==true)
        {
            EnemyController();
            TowerUpdate();
            moneyText.text = money.ToString() + ("$");
            
        }  
    }
    private void EnemyController()
    {
        if (currentWave < allMaps[currentMap].idEnemy.Count)
        {
            if (currentEnemy < allMaps[currentMap].idEnemy[currentWave].Count)
            {
                rateEnemies += Time.deltaTime;
                if (rateEnemies >= allMaps[currentMap].idEnemy[currentWave][currentEnemy].y)
                {
                    GameObject newEnemy = Instantiate(allEnemies[(int)allMaps[currentMap].idEnemy[currentWave][currentEnemy].x]);
                    newEnemy.GetComponent<EnemyControl>().SetEnemy(allMaps[currentMap].corners, this);
                    savedEnemies.Add(newEnemy);
                    rateEnemies = 0;
                    currentEnemy++;
                }
            }
            else
            {
                if (savedEnemies.Count == 0)
                {
                    currentEnemy = 0;
                    currentWave++;
                }
            }
        }
        else
        {
            FinalPanel.SetActive(true);
            finalText.text = ("!You Win!");
        }
    }
    private void MapCreator()
    {
        MapProperties newMap = new MapProperties();

        newMap = MapManager.Map0();
        allMaps.Add(newMap);

    }
    private void MapGenerator(int _map)
    {
        GameObject newEmpty = new GameObject("Map");
        for (int i = 0; i < allMaps[_map].idTile.Count; i++) //Filas
        {
            for (int j = 0; j < allMaps[_map].idTile[i].Count; j++) //Columnas
            {
                GameObject newTile = new GameObject("Tile_" + j + "-" + i);
                newTile.transform.position = new Vector2(j, i);
                newTile.AddComponent<SpriteRenderer>().sprite = allTiles[allMaps[_map].idTile[i][j]];
                newTile.transform.SetParent(newEmpty.transform);
            }
        }

    }
    public void DestroyEnemies(GameObject _enemy, bool _finish = false)
    {
        for (int i = 0; i < savedEnemies.Count; i++)
        {
            if(savedEnemies[i] == _enemy)
            {
                
                Destroy(_enemy);
                savedEnemies.RemoveAt(i);
                if (_finish == true)
                {
                    Lifes--;
                    if(Lifes >= 3)
                    {
                        H1.SetActive(true);
                        H2.SetActive(true);
                        H3.SetActive(true);
                    }
                    if (Lifes == 2)
                    {
                        GameObject newSound = Instantiate(allSounds[3]);
                        Destroy(newSound, 2);
                        H1.SetActive(true);
                        H2.SetActive(true);
                        H3.SetActive(false);
                    }
                    if (Lifes == 1)
                    {
                        GameObject newSound = Instantiate(allSounds[3]);
                        Destroy(newSound, 2);
                        H1.SetActive(true);
                        H2.SetActive(false);
                        H3.SetActive(false);
                    }
                    if (Lifes <= 0)
                    {
                        GameObject newSound = Instantiate(allSounds[3]);
                        Destroy(newSound, 2);
                        H1.SetActive(false);
                        H2.SetActive(false);
                        H3.SetActive(false);
                        isPlaying = false;
                        DeleteEnemies();
                        FinalPanel.SetActive(true);
                        finalText.text = ("!You Lose!");
                    }
                }
                else
                {
                    money += 1;
                }
                break;
            }
        }
    }
    private void DeleteEnemies()
    {
        for (int i = 0; i < savedEnemies.Count; i++)
        {
            Destroy(savedEnemies[i]);
        }
        savedEnemies.Clear();
        //Desactivar botones y actuvar el canvas de gameover
    }
    public void CreateTurret(GameObject _tower)
    {
        if(isPlaying==true)
        {
            GameObject newTower = Instantiate(_tower);
            currentTower = newTower;
        }  
    }
    private void TowerUpdate()
    {
        if(currentTower != null && Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 finalPos = mousePos;
            finalPos.x = (int)mousePos.x;
            if(mousePos.x > finalPos.x+0.5f)
            {
                finalPos.x++;
            }
            finalPos.y = (int)mousePos.y;
            if (mousePos.y > finalPos.y+0.5f)
            {
                finalPos.y++;
            }
            currentTower.transform.position = finalPos;
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(currentTower != null)
            {
                TowerControl tempTower = currentTower.GetComponent<TowerControl>();
                if (CheckPosTower(tempTower.whitelistTiles, currentTower.transform.position, tempTower.price) == true)
                {
                    currentTower.GetComponent<TowerControl>().InitTower(this);
                    if(currentTower.GetComponent<TowerControl>().type == TowerControl.towerType.ShootTower)
                    {
                        GameObject newSound = Instantiate(allSounds[0]);
                        Destroy(newSound, 3);
                    }
                    if (currentTower.GetComponent<TowerControl>().type == TowerControl.towerType.SlowTower)
                    {
                        GameObject newSound = Instantiate(allSounds[1]);
                        Destroy(newSound, 3);
                    }

                    money -= tempTower.price;
                    savedTowers.Add(currentTower);
                }
                else
                {
                    Destroy(currentTower);
                }
                currentTower = null;
            }
            
        }
    }
    private bool CheckPosTower(int[] _whiteList, Vector2 _pos, int _price)
    {
        if(money < _price)
        {
            return false;
        }
      
        for (int i = 0; i < savedTowers.Count; i++)
        {
            if(Vector2.Distance(_pos, (Vector2)savedTowers[i].transform.position) < 0.1f)
            {
                return false; 
            }
        }
        int tile = allMaps[currentMap].idTile[(int)_pos.y][(int)_pos.x];
        for (int i = 0; i < _whiteList.Length; i++)
        {
            if (tile == _whiteList[i]) return true;
        }
        return false;
    }
    public void RestartLevel()
    {

        FinalPanel.SetActive(false);
        SceneManager.LoadScene(1);
  
    }
    public void Home()
    {
        
        FinalPanel.SetActive(false);
        SceneManager.LoadScene(0);
        
    }
}

public class MapProperties
{
    public List<List<int>> idTile;
    public List<Vector2> corners;

    public List<List<Vector2>> idEnemy;
}