
using GameMain;
using UGFR = UnityGameFramework.Runtime;

public class Login : UGFR.UIFormLogic {

    private static ProcedureLogin procedureLogin;

    protected override void OnOpen(object userData) {
        procedureLogin = (ProcedureLogin)userData;
        this.InternalSetVisible(true);
    }
    
    /**
     * 单人游戏
     */
    public void SingleMode() {
        procedureLogin.SingleMode();
    }

    /**
     * 登录按钮事件
     */
    public void LoginButton() {
        procedureLogin.LoginButton();
    }

    /**
     * 打开注册窗口
     */
    public void OpenRegisterUI() {
        this.InternalSetVisible(false);
        procedureLogin.OpenRegisterUI();
    }
}
