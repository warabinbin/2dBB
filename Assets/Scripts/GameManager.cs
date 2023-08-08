using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("ボール")]
    public GameObject ballPrefab;
    [Header("ボールの速度")]
    public float speed = 10f;
    [Header("プレイヤ")]
    public GameObject playerPrefab;
    [Header("アイテム")]
    public GameObject[] itemPrefab;
    [Header("ステージ")]
    public GameObject[] stagePrefab;
    [Header("環境")]
    public GameObject Enviroment;
    [Header("パネル")]
    public GameObject panelMenu;
    public GameObject panelFinish;
    public GameObject panelStageClear;
    [Header("テキスト")]
    public Text finishText;
    public Text clearText;
    public Text hpText;
    [Header("残機")]
    public int Balls;

    public static GameManager instance { get; private set; }
    public enum Status { MENU, INIT, GAME, STAGECLEAR, LOADSTAGE, FINISH }
    Status _status;
    GameObject _stage;
    GameObject _ball;
    GameObject _player;
    GameObject _item;
    int _stageNo;
    int _itemNo;

    void Start()
    {
        Enviroment.SetActive(false);
        instance = this;
        _stageNo = 0;
        ChangeStatus(Status.MENU);
    }

    void Update()
    {
        switch (_status)
        {
            case Status.GAME:
                hpText.text = "残機:" + Balls;
                if (_ball == null)
                {
                    if (Balls > 0)
                    {
                        _ball = Instantiate(ballPrefab);
                    }
                    else
                    {
                        finishText.text = "GAME OVER";
                        ChangeStatus(Status.FINISH);
                    }
                }
                if (_stage != null && _stage.transform.childCount == 0)
                {
                    ChangeStatus(Status.STAGECLEAR);
                }
                break;
            case Status.FINISH:

                break;
            default:
                break;
        }

        //右クリックで一時停止
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void StartClick()
    {
        panelMenu.SetActive(false);
        ChangeStatus(Status.INIT);
    }

    public void NextStageClick()
    {
        panelStageClear.SetActive(false);
        ChangeStatus(Status.LOADSTAGE);
    }

    public void QuitGameClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ItemGenerate()
    {
        _itemNo = Random.Range(0,itemPrefab.Length);
        _item = Instantiate(itemPrefab[_itemNo]);
    }

    public void Item1()
    {
        //バー長くなる
        _player.transform.localScale = new Vector3(3.0f, 0.3f, 1.0f);
    }

    public void Item2()
    {
        //ボール増える
        _ball = Instantiate(ballPrefab);
        Balls++; //残機数
    }

    public void Item3()
    {
        //ボールが2倍の大きさ
        _ball.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    public void Item4()
    {
        //ボールの速さ
    }

    //Scene Reload
    async void ReloadScene()
    {
        await Task.Delay(1000);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //オブジェクト一括削除
    void DestroyBSPI()
    {
        Destroy(_ball);
        Destroy(_stage);
        Destroy(_player);
        Destroy(_item);
    }

    void ChangeStatus(Status nextstatus)
    {
        _status = nextstatus;
        switch (nextstatus)
        {
            case Status.MENU:
                panelMenu.SetActive(true);
                break;
            case Status.INIT:
                Enviroment.SetActive(true);
                ChangeStatus(Status.LOADSTAGE);
                break;
            case Status.GAME:
                _player = Instantiate(playerPrefab);
                break;
            case Status.STAGECLEAR:
                DestroyBSPI();
                Enviroment.SetActive(false);
                _stageNo++;

                if (_stageNo >= stagePrefab.Length)
                {
                    finishText.text = "GAME CLEAR";
                    ChangeStatus(Status.FINISH);
                }
                else
                {
                    clearText.text = "STAGE CLEAR";
                    panelStageClear.SetActive(true);
                }

                break;
            case Status.LOADSTAGE:
                _stage = Instantiate(stagePrefab[_stageNo]); 
                Enviroment.SetActive(true);
                ChangeStatus(Status.GAME);
                break;
            case Status.FINISH:
                DestroyBSPI();
                Enviroment.SetActive(false);
                panelFinish.SetActive(true);
                ReloadScene();
                break;
        }
    }
}