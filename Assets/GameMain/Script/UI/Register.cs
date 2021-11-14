
using GameMain;
using UnityEngine;
using UGFR = UnityGameFramework.Runtime;

public class Register : UGFR.UIFormLogic {

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
     * 注册按钮事件
     */
    public void RegisterButton() {
        procedureLogin.RegisterButton();
    }

    /**
     * 打开登录窗口
     */
    public void OpenLoginUI() {
        procedureLogin.OpenLoginUI(canvas);
    }

    public void SetSiblingIndex(int index) {
        this.transform.SetSiblingIndex(index);
    }
}
