public class GameContext {
    public int CurrendRound {
        get;
        set;
    }
    public int MaxHp {
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
    public int PublicDamage {
        get;
        set;
    }
    public GameUserInfo CurrentUser {
        get;
        set;
    }
    public bool IsReady {
        get;
        set;
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
}
