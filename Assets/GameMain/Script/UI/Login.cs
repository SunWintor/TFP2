
using GameMain;
using UGFR = UnityGameFramework.Runtime;

public class Login : UGFR.UIFormLogic {

    private static ProcedureLogin procedureLogin;

    protected override void OnOpen(object userData) {
        procedureLogin = (ProcedureLogin)userData;
        this.InternalSetVisible(true);
    }
    
    /**
     * ������Ϸ
     */
    public void SingleMode() {
        procedureLogin.SingleMode();
    }

    /**
     * ��¼��ť�¼�
     */
    public void LoginButton() {
        procedureLogin.LoginButton();
    }

    /**
     * ��ע�ᴰ��
     */
    public void OpenRegisterUI() {
        this.InternalSetVisible(false);
        procedureLogin.OpenRegisterUI();
    }
}
