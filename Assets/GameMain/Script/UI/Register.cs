
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
     * ע�ᰴť�¼�
     */
    public void RegisterButton() {
        procedureLogin.RegisterButton();
    }

    /**
     * �򿪵�¼����
     */
    public void OpenLoginUI() {
        this.InternalSetVisible(false);
        procedureLogin.OpenLoginUI();
    }
}
