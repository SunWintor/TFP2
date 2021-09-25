using UGFR = UnityGameFramework.Runtime;
using GameMain;
using Tutorial;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
    }

    /**
     * 关闭
     */
    public void CloseButton() {
        GameEntry.UI.CloseAllLoadedUIForms();
        GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Login.prefab", "DefaultGroup", this);
    }

    /**
     * 加
     */
    public void AddButton(int count) {
    }

    /**
     * 确认
     */
    public void ReadyButton() {
    }

}
