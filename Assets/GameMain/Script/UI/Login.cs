
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
        procedureLogin.OpenRegisterUI(canvas);
    }

    public void SetSiblingIndex(int index) {
        this.transform.SetSiblingIndex(index);
    }
}
