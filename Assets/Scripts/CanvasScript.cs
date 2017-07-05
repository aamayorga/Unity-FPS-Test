using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

    public float welcomeScreenTime;
    public float enemyScreenTime;
    public float winScreenTime;

    public Text welcomeText;
    public Text enemyText;
    public Text winText;

    private Text panelText;
    private GameObject panelComponent;
    private GameMasterScript eventMasterScript;

    void OnEnable() {
        SetInitialReferences();
        eventMasterScript.spawnEnemies += showEnemyCanvas;
        eventMasterScript.enemiesCleared += showWinCanvas;
    }

    void OnDisable() {
        eventMasterScript.spawnEnemies -= showEnemyCanvas;
        eventMasterScript.enemiesCleared -= showWinCanvas;
    }

	void Start () {
        // Then show the screen for however many seconds specificed in welcomeScreenTime
        StartCoroutine(showCanvas(welcomeScreenTime, welcomeText));
	}

    IEnumerator showCanvas(float waitTime, Text text) {
        // Activate Text Panel
        // Show for the specified amount of seconds
        // Deactivate Text Panel
        panelText = text;
        panelText.gameObject.SetActive(true);
        panelComponent.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        panelText.gameObject.SetActive(false);
        panelComponent.SetActive(false);
    }

    void showEnemyCanvas() {
        StartCoroutine(showCanvas(enemyScreenTime, enemyText));
    }

    void showWinCanvas() {
        StartCoroutine(showCanvas(winScreenTime, winText));
    }

    void SetInitialReferences() {
        // Get reference to Game Master, Panel, and Text
        eventMasterScript = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        panelComponent = GameObject.Find("Panel");
        panelText = panelComponent.GetComponent<Text>();
    }
}
