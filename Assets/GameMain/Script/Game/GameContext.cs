public class GameContext {
    public int CurrendRound;
    public int MaxHp;
    public int CurrentHp;
    public PayHp RoundPayHp;
    public int PublicDamage;


}

public class GameUserInfo {
    public string userName;
    public int userId;
}

public class PayHp {
    public GameUserInfo payUser;
    public int payHp;
}