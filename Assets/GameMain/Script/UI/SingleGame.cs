using UGFR = UnityGameFramework.Runtime;
using GameMain;
using Tutorial;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
    }

    /**
     * �ر�
     */
    public void CloseButton() {
        GameEntry.UI.CloseAllLoadedUIForms();
        GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Login.prefab", "DefaultGroup", this);
    }

    /**
     * ��
     */
    public void AddButton(int count) {
    }

    /**
     * ȷ��
     */
    public void ReadyButton() {
    }

}
