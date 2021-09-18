
using GameMain;
using UnityGameFramework.Runtime;

public class Login : UIFormLogic {

    private ProcedureLogin procedureLogin;

    protected override void OnOpen(object userData) {
        procedureLogin = (ProcedureLogin)userData;
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
     * ע�ᰴť�¼�
     */
    public void RegisterButton() {
        procedureLogin.RegisterButton();
    }
    /**
     * �򿪵�¼����
     */
    public void OpenLoginUI() {
        procedureLogin.OpenLoginUI();
    }

    /**
     * ��ע�ᴰ��
     */
    public void OpenRegisterUI() {
        procedureLogin.OpenRegisterUI();
    }
}
