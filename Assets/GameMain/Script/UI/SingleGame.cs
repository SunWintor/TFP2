using UGFR = UnityGameFramework.Runtime;
using GameMain;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;
    // ������Ϸ��������
    private static GameContext gameContext;
    // ��ҳ������
    private Canvas canvas = null;
    // ��¼ʣ��������
    private Text textCurrentAmount = null;
    // ��¼����ҪͶע����
    private Text textAmount = null;
    // ��¼��ǰ�غ�
    private Text textRound = null;
    // ��¼��ǰ�غ�ʣ��ʱ��
    private Text textTime = null;
    // ��ʱ�õġ�
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
        gameContext.CurrentUser.UserName = "����������";
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
        textTime.text = "ʣ�� " + time + " ��";
    }

    private void SetRound(int round) {
        textRound.text = "�� " + round + " �غ�";
    }

    private void SetAmount(int amount) {
        textAmount.text = "������� " + amount;
    }

    private void SetCurrentAmount(int amount) {
        textCurrentAmount.text = "ʣ���� " + amount;
    }

    /**
     * �ر�
     */
    public void CloseButton() {
        canvas.sortingOrder = -1;
        procedureSingleMode.ChangeToLogin();
    }

    /**
     * ��
     */
    public void AddButton(int count) {
        // todo �غϽ���ʱ���ı�״̬
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
     * ȷ��
     */
    public void ReadyButton() {
        gameContext.CurrentUser.IsReady = true;
    }

}
