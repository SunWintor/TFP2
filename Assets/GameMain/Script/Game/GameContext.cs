using System.Collections.Generic;

public class GameContext {
    public int CurrendRound {
        get;
        set;
    }
    public int PublicDamage {
        get;
        set;
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

public class GameUserInfo {
    public string UserName {
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
