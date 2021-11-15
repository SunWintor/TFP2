using System;
using System.Collections.Generic;

public class GameContext {
    public GameContext(GameUserInfo currentUser) {
        CurrentUser = currentUser;
        TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
        Rand = new Random((int)(ts.TotalMilliseconds % 1000000));
        CurrendRound = 1;
        SetPublicDamage();
        EnemyList = new List<GameUserInfo>();
        EnemyList.Add(new GameUserInfo("敌人1", 2, 108));
        EnemyList.Add(new GameUserInfo("敌人2", 3, 108));
        EnemyList.Add(new GameUserInfo("敌人3", 4, 108));
        EnemyList.Add(new GameUserInfo("敌人4", 5, 108));
        EnemyList.Add(new GameUserInfo("敌人5", 6, 108));
        EnemyList.Add(new GameUserInfo("敌人6", 7, 108));
        EnemyList.Add(new GameUserInfo("敌人7", 8, 108));
    }

    public int CurrendRound {
        get;
        set;
    }
    public int PublicDamage {
        get;
        set;
    }
    public Random Rand {
        get;
    }
    public GameUserInfo CurrentUser {
        get;
        set;
    }
    public List<GameUserInfo> EnemyList {
        get;
        set;
    }
    public void SetPublicDamage() {
        PublicDamage = CurrendRound + 2;
    }
    public void RoundUp() {
        CurrendRound++;
        SetPublicDamage();
    }
}

public class Puppet {
    public Puppet(GameUserInfo master) {
        Master = master;
        PayHp = master.RoundPayHp;
        TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
        Rand = new Random((int)(ts.TotalMilliseconds % 1000000));
        HP = Rand.Next(PayHp * 9, PayHp * 10 + 1);
        ATK = Rand.Next(PayHp * 4, PayHp * 6 + 1);
        DEF = Rand.Next(0, PayHp * 2 + 1);
        SPD = Rand.Next(2000 / (10 * PayHp + 1), 4000 / (10 * PayHp + 1));
    }

    // 攻击
    // target : 被攻击的目标
    public int Attack(Puppet target) {
        if (DEAD) {
            return 0;
        }
        int damage = this.ATK - target.DEF;
        if (damage < 0) {
            damage = 0;
        }
        target.HP -= damage;
        target.Dead();
        return damage;
    }

    public void Dead() {
        if (HP > 0) {
            return;
        }
        DEAD = true;
    }

    public String PrintString() {
        return "玩家：" + Master.UserName + " 的傀儡属性为：\n" +
            "HP：" + HP + "\nATK：" + ATK + "\nDEF：" + DEF + "\nSPD：" + SPD;
    }

    public Random Rand {
        get;
    }

    public GameUserInfo Master {
        get;
        set;
    }
    // 创建该傀儡用了多少血
    public int PayHp {
        get;
        set;
    }
    // 血量
    public int HP {
        get;
        set;
    }
    // 攻击力
    public int ATK {
        get;
        set;
    }
    // 防御力
    public int DEF {
        get;
        set;
    }
    // 速度
    public int SPD {
        get;
        set;
    }
    // 已经死了
    public bool DEAD {
        get;
        set;
    }
}

public class GameUserInfo {
    public GameUserInfo(string userName, int userId, int currentHp) {
        UserName = userName;
        UserId = userId;
        CurrentHp = currentHp;
    }

    public int SetRoundHp(int count) {
        RoundPayHp += count;
        if (RoundPayHp < 0) {
            RoundPayHp = 0;
        }
        if (RoundPayHp > CurrentHp) {
            RoundPayHp = CurrentHp;
        }
        return RoundPayHp;
    }

    public void PublicDamage(int count) {
        SubHp(count);
    }

    public void UseHp() {
        SubHp(RoundPayHp);
        RoundPayHp = 0;
    }

    private void SubHp(int subCount) {
        CurrentHp -= subCount;
        IsDead();
    }

    private void IsDead() {
        if (CurrentHp == 0) {
            Dead = true;
        }
    }

    public string UserName {
        get;
        set;
    }
    public bool Dead {
        get;
        set;
    }
    public int UserId {
        get;
        set;
    }
    public int CurrentHp {
        get;
        set;
    }
    public int RoundPayHp {
        get;
        set;
    }
    public bool IsReady {
        get;
        set;
    }
}

