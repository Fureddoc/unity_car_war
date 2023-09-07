using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float currentTime;
    public bool isEnded;
    public bool isStarted;

    public GameObject playerPrefab;
    public Character player;

    private WaveManager waveManager;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        isEnded = false;
        isStarted = false;

        waveManager = GetComponent<WaveManager>();
        uiManager = GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted&&!isEnded)
        {
            currentTime += Time.deltaTime;
        }
    }

    public void StartCountDown()
    {
        // Count down
        StartCoroutine(StartCountDownAsync());
    }

    IEnumerator StartCountDownAsync()
    {
        uiManager.Countdown(3);
        yield return new WaitForSeconds(1f);
        uiManager.Countdown(2);
        yield return new WaitForSeconds(1f);
        uiManager.Countdown(1);
        yield return new WaitForSeconds(1f);
        uiManager.Countdown(0);
        StartGame();

        for(int i = 9; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            uiManager.ChangeCountdownTransparency(i/10);
        }
    }

    public void StartGame()
    {

        // Spawn player
        // プレイヤーを生成する
        var playerGO = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        player = playerGO.GetComponent<Character>();

        // Spawn enemies (start wave 1)
        // 敵を生成する (ウエーブ1を開始する)
        waveManager.StartWave(1);

        // Start time counter
        // タイマーを開始する
        isStarted = true;
    }

    public void EndGame()
    {
        isEnded = true;
        waveManager.StopWave();

        Invoke("ShowEndPanelDelay", 1f);
    }

    private void ShowEndPanelDelay()
    {

        uiManager.ShowEndPanel();
    }

    public void RestartGame()
    {
        // Reload current scene
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}
