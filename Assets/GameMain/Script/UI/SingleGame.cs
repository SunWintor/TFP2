using UGFR = UnityGameFramework.Runtime;
using GameMain;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
    // ��¼��Ϣ��
    private Text chatText = null;
    // ��ʱ�õġ�
    public int TotalTime = 60;

    private bool waring = false;
    bool gameEnd = false;

    private void Update() {
        if (TotalTime <= 0 && !gameContext.CurrentUser.Dead && !waring && !gameEnd) {
            waring = true;
            SetChatText("\n\n��" + gameContext.CurrendRound + "�غϿ�ʼ��\n");
            UGFR.Log.Debug("game start");
            ReadyButton();
            StartWar(); // ս��
            if (gameContext.CurrentUser.Dead) {
                SetChatText("��Ϸ���������ʧ�ܡ�");
                return;
            } else {
                gameEnd = true;
                foreach (var enemy in gameContext.EnemyList) {
                    if (!enemy.Dead) {
                        gameEnd = false;
                        break;
                    }
                }
                if (gameEnd) {
                    SetChatText("��Ϸ���������ʤ����");
                    return;
                }
            }
            gameContext.RoundUp(); // �غϱ���������Ϸû�н����Ļ���
            SetRound();
            SetAmount();
            gameContext.CurrentUser.IsReady = false;
            TotalTime = 60;
            waring = false;
        }
    }

    private void StartWar() {
        Dictionary<int, Puppet> puppetMap = InitEnemyPayHp();
        UGFR.Log.Debug("puppetMap" + puppetMap);
        Puppet PlayerPuppet = new Puppet(gameContext.CurrentUser);
        puppetMap[-1] = PlayerPuppet;
        UGFR.Log.Debug("PlayerPuppet" + PlayerPuppet);
        SetChatText("��ң�" + gameContext.CurrentUser.UserName + " �ľ������Ϊ��" + gameContext.CurrentUser.RoundPayHp);
        gameContext.CurrentUser.UseHp();
        SetCurrentAmount();
        SetChatText(PlayerPuppet.PrintString());
        War(puppetMap);
    }

    private void War(Dictionary<int, Puppet> puppetMap) {
        UGFR.Log.Debug("War puppetMap" + puppetMap);
        List<Puppet> lifeList = new List<Puppet>();
        foreach (KeyValuePair<int, Puppet> kvp in puppetMap) {
            lifeList.Add(kvp.Value);
        }
        for (int i = 1; i < 100000 ;i++) {
            foreach (KeyValuePair<int, Puppet> kvp in puppetMap) {
                if (kvp.Value.DEAD || kvp.Value.SPD == 0) {
                    continue;
                }
                if (i % kvp.Value.SPD != 0) {
                    continue;
                }
                int randN = 0;
                Puppet target = null;
                for (int j = 0; j < 100; j++ ) {
                    randN = gameContext.Rand.Next(0, lifeList.Count);
                    UGFR.Log.Debug("randN " + randN + " length " + lifeList.Count);
                    if (lifeList[randN].Master.UserId != kvp.Value.Master.UserId) {
                        target = lifeList[randN];
                        break;
                    }
                }
                int damage = kvp.Value.Attack(target);
                SetChatText(kvp.Value.Master.UserName + " �Ŀ����� " + target.Master.UserName + 
                    " �Ŀ��ܷ����˹����������" + damage + "���˺�");
                SetChatText(target.Master.UserName + " �Ŀ���ʣ��Ѫ����" + target.HP);
                if (target.DEAD) {
                    SetChatText(target.Master.UserName + " �Ŀ��ܱ������ˡ�");
                    lifeList.Remove(target);
                    if (lifeList.Count == 1) {
                        foreach (KeyValuePair<int, Puppet> kvp2 in puppetMap) {
                            if (kvp2.Value.DEAD) {
                                kvp2.Value.Master.PublicDamage(gameContext.PublicDamage);
                                SetChatText(kvp2.Value.Master.UserName + "�ܵ������˺���" + gameContext.PublicDamage
                                    + "ʣ���" + kvp2.Value.Master.CurrentHp);
                            } else {
                                SetChatText(kvp2.Value.Master.UserName + "δ�ܵ������˺���ʣ���" + kvp2.Value.Master.CurrentHp);
                            }
                        }
                        return;
                    }
                }
            }
        }
    }

    // �����������ֵ���غϾ�������Χ��0������ѹ��+1
    private Dictionary<int, Puppet> InitEnemyPayHp() {
        Dictionary<int, Puppet> res = new Dictionary<int, Puppet>();
        string printString = "";
        for (int i = 0; i < gameContext.EnemyList.Count; i++ ) {
            GameUserInfo enemy = gameContext.EnemyList[i];
            if (enemy.Dead) {
                continue;
            }
            enemy.SetRoundHp(gameContext.Rand.Next(0, gameContext.PublicDamage + 2));
            res[i] = new Puppet(enemy);
            printString += "���ˣ�" + enemy.UserName + " �ľ������Ϊ��" + enemy.RoundPayHp + "\n";
            enemy.UseHp();
        }
        SetChatText(printString);
        return res;
    }

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
        gameContext = new GameContext(new GameUserInfo("����������", 1, 108));
        UGFR.Log.Debug("game start" + (int)(1 % 1000000));
    }

    private void Start() {
        // ��ʼ��ҳ��
        canvas = this.gameObject.transform.parent.transform.parent.GetComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = 2;
        textAmount = GameObject.Find("TextAmount").GetComponent<Text>();
        textCurrentAmount = GameObject.Find("TextCurrentAmount").GetComponent<Text>();
        textRound = GameObject.Find("TextRound").GetComponent<Text>();
        textTime = GameObject.Find("TextTime").GetComponent<Text>();
        chatText = GameObject.Find("ChatText").GetComponent<Text>();
        // ��ʼ������
        SetRound();
        SetCurrentAmount();
        StartCoroutine(Time());
    }

    IEnumerator Time() {
        SetTime();
        while (TotalTime >= 0) {
            SetTime();
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
    }

    private void SetChatText(string text) {
        chatText.text = chatText.text + "\n" + text;
    }

    private void SetTime() {
        textTime.text = "ʣ�� " + TotalTime + " ��";
    }

    private void SetRound() {
        textRound.text = "�� " + gameContext.CurrendRound + " �غ�";
    }

    private void SetAmount() {
        textAmount.text = "������� " + gameContext.CurrentUser.RoundPayHp;
    }

    private void SetCurrentAmount() {
        textCurrentAmount.text = "ʣ���� " + gameContext.CurrentUser.CurrentHp;
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
        gameContext.CurrentUser.SetRoundHp(count);
        SetAmount();
    }

    /**
     * ȷ��
     */
    public void ReadyButton() {
        gameContext.CurrentUser.IsReady = true;
        TotalTime = 0;
    }

}
