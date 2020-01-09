using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleMgr : MonoBehaviour {

    static public BattleMgr ins;
    static public string BattleSceneName = "Scenes/Battle";

    void Awake() {
        ins = this;
    }

    void Start() {

    }

    void Update() {

    }

    public void beginBattle() {
        StartCoroutine(loadBattleAsyncScene());
    }

    public void endBattle() {
        StartCoroutine(unLoadBattleAsyncScene());
    }

    IEnumerator loadBattleAsyncScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(BattleMgr.BattleSceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }

    IEnumerator unLoadBattleAsyncScene() {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(BattleMgr.BattleSceneName);
        while (!asyncUnload.isDone) {
            yield return null;
        }
    }

    public void generateMap(int level) {

    }
}
