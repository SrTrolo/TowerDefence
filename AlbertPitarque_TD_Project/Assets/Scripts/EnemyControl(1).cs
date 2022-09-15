using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    private float initSpeed;
    private List<Vector2> allPath;
    private int currentCorner;
    public GameManager manager;
    public float lifes;
    public ParticleSystem explosion;
    public List<GameObject> allSounds;
    public void SetEnemy(List<Vector2> _path, GameManager _mng)
    {
        initSpeed = speed;
        manager = _mng;
        allPath = _path;
        transform.position = allPath[0];
        
    }
    void Start()
    {
        GameObject newSound = Instantiate(allSounds[1]);
        newSound.transform.SetParent(gameObject.transform);
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, allPath[currentCorner], speed * Time.deltaTime);

        Vector2 dir = allPath[currentCorner] - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion finalRot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, finalRot, 600 * Time.deltaTime);

        if ((Vector2)transform.position == allPath[currentCorner])
        {
            currentCorner++;
            if (currentCorner >= allPath.Count)
            {
                manager.DestroyEnemies(gameObject, true);
            }
        }
    }
    public void GetDamage(int _damage)
    {
        lifes -= _damage;
        if(lifes<=0)
        {
            //daño
            manager.DestroyEnemies(gameObject);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            GameObject newSound = Instantiate(allSounds[0]);
            Destroy(newSound, 3);
        }
        else
        {
            //muerte
        }
    }

    public void SetSpeed(float _percent)
    {
        float percent = (float)_percent / 100;
        float finalPercent = 1 - percent;
        speed = initSpeed * finalPercent;
    }
    public void ResetSpeed()
    {
        speed = initSpeed;
    }
}
