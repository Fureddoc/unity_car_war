using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public struct WaveInfo
    {
        public GameObject enemyPrefab;
        public int numOfSpawn;
        public Vector2 position;
    }

    // wave count from 1, 1 = Wave 1, 2 = Wave 2
    public int currentWave = -1;
    [SerializeField] public WaveInfo[] waveInfos;

    public BoxCollider2D spawnRange;

    private int spawnDuration = 20;
    private int spawnNum = 5;
    
    public void StartWave(int wave)
    {
        currentWave = wave;
        StartCoroutine(StartWaveInternal(currentWave));
    }

    IEnumerator StartWaveInternal(int wave)
    {
        Debug.Log("Wave "+currentWave+": spawn "+ spawnNum + " enemies");

        var waveInfo = waveInfos[0];

        for (var i = 0; i < spawnNum; i++)
        {
            // random position in rect
			// 敵の生成位置はランダム
            Vector2 pos = new Vector2(
                Random.Range(spawnRange.bounds.min.x, spawnRange.bounds.max.x),
                Random.Range(spawnRange.bounds.min.y, spawnRange.bounds.max.y));

            Debug.Log("Spawn Position: "+ pos);

            Instantiate(waveInfo.enemyPrefab, pos, Quaternion.identity);
        }
        
        // set timer for next wave
		// 次のウェーブまでの時間
        spawnDuration--;
        spawnDuration = Mathf.Max(5, spawnDuration);
        
        Debug.Log("Next wave is coming in " + spawnDuration + " s");
        yield return new WaitForSeconds(spawnDuration);
        
        // increase spawn enemy in next wave
		// ウェーブ数によって、敵を増やす
        spawnNum++;
        currentWave++;
        
        // Start next wave
        StartCoroutine(StartWaveInternal(currentWave));
    }

    public void StopWave()
    {
        StopCoroutine("StartWaveInternal");
    }
}
