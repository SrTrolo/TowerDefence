using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeSpawn : MonoBehaviour
{
    public List<GameObject> allSounds;

    public GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newSound = Instantiate(allSounds[0]);
        Destroy(newSound, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void SpawnSlime()
    {
        
        
            Randomize();
            Vector3 position = new Vector3(Random.Range(2f, 17f), 12, 0);
            Instantiate(slime, position, Quaternion.identity);


        
    }
    public void Randomize()
    {
        slime.transform.GetComponent<SpriteRenderer>().color = new Color((float)Random.Range(0f, 1f), (float)Random.Range(0f, 1f), (float)Random.Range(0f, 1f));
        

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    GameObject InstantiateRandomScale(GameObject _slime, float minScale,float maxScale)
    {
        GameObject clone = Instantiate(_slime) as GameObject;
        clone.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        return clone;
    }
}
