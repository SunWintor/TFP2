using UGFR = UnityGameFramework.Runtime;
using GameMain;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
    // 记录信息栏
    private Text chatText = null;
    // 计时用的。
    public int TotalTime = 60;

    private bool waring = false;
    bool gameEnd = false;

    private void Update() {
        if (TotalTime <= 0 && !gameContext.CurrentUser.Dead && !waring && !gameEnd) {
            waring = true;
            SetChatText("\n\n第" + gameContext.CurrendRound + "回合开始：\n");
            UGFR.Log.Debug("game start");
            ReadyButton();
            StartWar(); // 战斗
            if (gameContext.CurrentUser.Dead) {
                SetChatText("游戏结束，玩家失败。");
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
                    SetChatText("游戏结束，玩家胜利。");
                    return;
                }
            }
            gameContext.RoundUp(); // 回合变更（如果游戏没有结束的话）
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
        SetChatText("玩家：" + gameContext.CurrentUser.UserName + " 的捐赠额度为：" + gameContext.CurrentUser.RoundPayHp);
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
                SetChatText(kvp.Value.Master.UserName + " 的傀儡向 " + target.Master.UserName + 
                    " 的傀儡发起了攻击。造成了" + damage + "点伤害");
                SetChatText(target.Master.UserName + " 的傀儡剩余血量：" + target.HP);
                if (target.DEAD) {
                    SetChatText(target.Master.UserName + " 的傀儡被消灭了。");
                    lifeList.Remove(target);
                    if (lifeList.Count == 1) {
                        foreach (KeyValuePair<int, Puppet> kvp2 in puppetMap) {
                            if (kvp2.Value.DEAD) {
                                kvp2.Value.Master.PublicDamage(gameContext.PublicDamage);
                                SetChatText(kvp2.Value.Master.UserName + "受到舆论伤害：" + gameContext.PublicDamage
                                    + "剩余金额：" + kvp2.Value.Master.CurrentHp);
                            } else {
                                SetChatText(kvp2.Value.Master.UserName + "未受到舆论伤害，剩余金额：" + kvp2.Value.Master.CurrentHp);
                            }
                        }
                        return;
                    }
                }
            }
        }
    }

    // 给敌人随机赋值本回合捐赠，范围是0到舆论压力+1
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
            printString += "敌人：" + enemy.UserName + " 的捐赠额度为：" + enemy.RoundPayHp + "\n";
            enemy.UseHp();
        }
        SetChatText(printString);
        return res;
    }

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
        gameContext = new GameContext(new GameUserInfo("单机玩家李俊龙", 1, 108));
        UGFR.Log.Debug("game start" + (int)(1 % 1000000));
    }

    private void Start() {
        // 初始化页面
        canvas = this.gameObject.transform.parent.transform.parent.GetComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = 2;
        textAmount = GameObject.Find("TextAmount").GetComponent<Text>();
        textCurrentAmount = GameObject.Find("TextCurrentAmount").GetComponent<Text>();
        textRound = GameObject.Find("TextRound").GetComponent<Text>();
        textTime = GameObject.Find("TextTime").GetComponent<Text>();
        chatText = GameObject.Find("ChatText").GetComponent<Text>();
        // 初始化数据
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
        textTime.text = "剩余 " + TotalTime + " 秒";
    }

    private void SetRound() {
        textRound.text = "第 " + gameContext.CurrendRound + " 回合";
    }

    private void SetAmount() {
        textAmount.text = "捐赠金额 " + gameContext.CurrentUser.RoundPayHp;
    }

    private void SetCurrentAmount() {
        textCurrentAmount.text = "剩余金额 " + gameContext.CurrentUser.CurrentHp;
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
        gameContext.CurrentUser.SetRoundHp(count);
        SetAmount();
    }

    /**
     * 确认
     */
    public void ReadyButton() {
        gameContext.CurrentUser.IsReady = true;
        TotalTime = 0;
    }

}
