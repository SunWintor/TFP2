using UGFR = UnityGameFramework.Runtime;
using GameMain;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;
    // 整局游戏的上下文
    private static GameContext gameContext;
    // 本页面的面板
    private Canvas canvas = null;
    // 记录剩余金币数量
    private Text textCurrentAmount = null;
    // 记录本局要投注多少
    private Text textAmount = null;
    // 记录当前回合
    private Text textRound = null;
    // 记录当前回合剩余时间
    private Text textTime = null;
    // 计时用的。
    public int TotalTime = 60;

    private void Update() {
        if (TotalTime == 0) {
            UGFR.Log.Debug("game over");
        }
    }

    private void StartWar() {
        
    }

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
        gameContext = new GameContext();
        gameContext.CurrentUser = new GameUserInfo();
        gameContext.CurrentUser.UserId = 1;
        gameContext.CurrentUser.UserName = "单机玩家李俊龙";
        gameContext.CurrentUser.CurrentHp = 108;
        gameContext.SetPublicDamage();
    }

    private void Start() {
        canvas = this.gameObject.transform.parent.transform.parent.GetComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = 2;
        textAmount = GameObject.Find("TextAmount").GetComponent<Text>();
        textCurrentAmount = GameObject.Find("TextCurrentAmount").GetComponent<Text>();
        textRound = GameObject.Find("TextRound").GetComponent<Text>();
        textTime = GameObject.Find("TextTime").GetComponent<Text>();
        SetRound(1);
        UGFR.Log.Debug("gameContext.CurrentHp " + gameContext.CurrentUser.CurrentHp);
        SetCurrentAmount(gameContext.CurrentUser.CurrentHp);
        StartCoroutine(Time());
    }

    IEnumerator Time() {
        while (TotalTime >= 0) {
            SetTime(TotalTime);
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
    }

    private void SetTime(int time) {
        textTime.text = "剩余 " + time + " 秒";
    }

    private void SetRound(int round) {
        textRound.text = "第 " + round + " 回合";
    }

    private void SetAmount(int amount) {
        textAmount.text = "捐赠金额 " + amount;
    }

    private void SetCurrentAmount(int amount) {
        textCurrentAmount.text = "剩余金额 " + amount;
    }

    /**
     * 关闭
     */
    public void CloseButton() {
        canvas.sortingOrder = -1;
        procedureSingleMode.ChangeToLogin();
    }

    /**
     * 加
     */
    public void AddButton(int count) {
        // todo 回合结束时，改变状态
        if (gameContext.CurrentUser.IsReady) {
            return;
        }
        gameContext.CurrentUser.RoundPayHp += count;
        if (gameContext.CurrentUser.RoundPayHp < 0) {
            gameContext.CurrentUser.RoundPayHp = 0;
        }
        if (gameContext.CurrentUser.RoundPayHp > gameContext.CurrentUser.CurrentHp) {
            gameContext.CurrentUser.RoundPayHp = gameContext.CurrentUser.CurrentHp;
        }
        SetAmount(gameContext.CurrentUser.RoundPayHp);
    }

    /**
     * 确认
     */
    public void ReadyButton() {
        gameContext.CurrentUser.IsReady = true;
    }

}
