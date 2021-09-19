
using GameMain;
using Tutorial;
using UGFR = UnityGameFramework.Runtime;

public class Register : UGFR.UIFormLogic {

    private static ProcedureLogin procedureLogin;

    protected override void OnOpen(object userData) {
        procedureLogin = (ProcedureLogin)userData;
        this.InternalSetVisible(true);
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
        this.InternalSetVisible(false);
        procedureLogin.OpenLoginUI();
    }
}
