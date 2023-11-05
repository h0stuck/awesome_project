using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyWave
{
    public int type;
    public float posX;
    public float posY;
    public float time;
    public EnemyWave(int type, float posX, float posY, float time)
    {
        this.type = type; this.posX = posX; this.posY = posY; this.time = time;
    }
}

public class WaveSystem : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<EnemyWave> wave;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        wave.Add(new EnemyWave(0, 0, 0, 1));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= wave[0].time)
        {
            Spawn(wave[0]);
            wave.Remove(wave[0]);
        }
    }

    private void Spawn(EnemyWave ew)
    {
        Instantiate(enemyPrefabs[ew.type]);
    }
}
