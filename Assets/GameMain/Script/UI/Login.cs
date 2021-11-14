
using GameMain;
using UnityEngine;
using UGFR = UnityGameFramework.Runtime;

public class Login : UGFR.UIFormLogic {

    private static ProcedureLogin procedureLogin;

    private Canvas canvas = null;

    protected override void OnOpen(object userData) {
        procedureLogin = (ProcedureLogin)userData;
        this.InternalSetVisible(true);
    }

    private void Start() {
        canvas = this.gameObject.transform.parent.transform.parent.GetComponent<Canvas>();
        canvas.overrideSorting = true;
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
        procedureLogin.OpenRegisterUI(canvas);
    }

    public void SetSiblingIndex(int index) {
        this.transform.SetSiblingIndex(index);
    }
}
