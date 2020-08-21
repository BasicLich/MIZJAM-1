using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum WorldState { IDLE, CHARGING, BOSS };
public class BossBar : MonoBehaviour
{

    public static BossBar instance;
    public Image fillImage;
    public WordBuilder word;
    public float maxBossBar = 20000;
    public float currentBossBar = 0;
    public Transform bossPosition;
    public Unit boss;
    public float bossBarDecreasePerSecond = 100f;

    public WorldState state;




    private void Awake() {
        instance = this;
    }


    public void EnemyDied() {

        //print("WTF");
        currentBossBar += 1000;
        
    }


    public void StartFighting() {
        state = WorldState.CHARGING;
        gameObject.SetActive(true);
        fillImage.fillAmount = currentBossBar / maxBossBar;
    }


    private void Update() {

        switch (state) {
            case WorldState.IDLE:

                break;
            case WorldState.CHARGING:

                if (currentBossBar >= maxBossBar) {
                    fillImage.fillAmount = 1;
                    GoToBossState();
                } else {
                    currentBossBar -= bossBarDecreasePerSecond * Time.deltaTime;
                    currentBossBar = Mathf.Max(0, currentBossBar);
                    fillImage.fillAmount = currentBossBar / maxBossBar;
                }

                break;
            case WorldState.BOSS:


                fillImage.fillAmount = (float)boss.HP / (float)boss.MaxHP;

                break;
        }


    }


    public void GoToBossState () {


        state = WorldState.BOSS;
        boss = Instantiate(boss, bossPosition.position, Quaternion.identity);
        word.words = "DEUS REX";
        word.CreateWord();
        EnemySpawner.instance.SwitchToBossFight();
        AudioManager.instance.PlayTrack(2);
        

    }






}
