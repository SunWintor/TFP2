using UGFR = UnityGameFramework.Runtime;
using Tutorial;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;
    private static GameContext gameContext;

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
        gameContext = new GameContext();
        gameContext.CurrentUser = new GameUserInfo();
        //gameContext.CurrentUser.UserId = ;
        //gameContext.CurrentUser.UserName = ;
    }

    private void Update() {
        // todo 
    }

    /**
     * �ر�
     */
    public void CloseButton() {
        GameEntry.UI.CloseAllLoadedUIForms();
        GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Login.prefab", "DefaultGroup", this);
    }

    /**
     * ��
     */
    public void AddButton(int count) {
        // todo �غϽ���ʱ���ı�״̬
        if (gameContext.IsReady) {
            return;
        }
        gameContext.RoundPayHp += count;
        if (gameContext.RoundPayHp < 0) {
            gameContext.RoundPayHp = 0;
        }
        if (gameContext.RoundPayHp > gameContext.CurrentHp) {
            gameContext.RoundPayHp = gameContext.CurrentHp;
        }
    }

    /**
     * ȷ��
     */
    public void ReadyButton() {
        gameContext.IsReady = true;
    }

}
