using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image healthBG;
    public Image health;
    public Text currentWave;
    public Text currentTime;
    public Text countdown;
    public Text killCount;

    public GameObject endPanel;
    public Text endPanelTimeText;

    private GameManager gameManager;
    private WaveManager waveManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        waveManager = GetComponent<WaveManager>();

        endPanel.SetActive(false);
        countdown.text = "";
        ChangeCountdownTransparency(1);
        killCount.text = "キル : 0";

    }

    // Update is called once per frame
    void Update()
    {

        TimeSpan timeSpan = TimeSpan.FromSeconds(gameManager.currentTime);
        string timeText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        currentTime.text = timeText;

        if (gameManager.player != null)
        {
            health.enabled = true;
            healthBG.enabled = true;
            health.fillAmount = gameManager.player.health / 100f;
        }
        else
        {
            health.enabled = false;
            healthBG.enabled = false;
        }

        currentWave.text = "ウェーブ : " + waveManager.currentWave.ToString();
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
        endPanelTimeText.text = "生存時間" + currentTime.text;
    }

    public void Countdown(int sec)
    {
        countdown.text = (sec != 0) ? sec.ToString() : "START!";
    }

    public void ChangeCountdownTransparency(float a)
    {
        var color = countdown.color;
        color.a = a;
        countdown.color = color;
    }

    public void UpdateKillCount(int kill)
    {
        killCount.text = "キル : " + kill;
    }
}
