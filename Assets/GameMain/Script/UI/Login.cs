
using GameMain;
using UnityGameFramework.Runtime;

public class Login : UIFormLogic {

    private ProcedureLogin procedureLogin;

    protected override void OnOpen(object userData) {
        procedureLogin = (ProcedureLogin)userData;
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
     * 注册按钮事件
     */
    public void RegisterButton() {
        procedureLogin.RegisterButton();
    }
    /**
     * 打开登录窗口
     */
    public void OpenLoginUI() {
        procedureLogin.OpenLoginUI();
    }

    /**
     * 打开注册窗口
     */
    public void OpenRegisterUI() {
        procedureLogin.OpenRegisterUI();
    }
}
