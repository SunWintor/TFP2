using UGFR = UnityGameFramework.Runtime;
using GameMain;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
    }

    /**
     * �ر�
     */
    public void CloseButton() {
        UGFR.Log.Debug("CloseButton");
    }

    /**
     * ��
     */
    public void AddButton(int count) {
        UGFR.Log.Debug("AddButton" + count);
    }

    /**
     * ȷ��
     */
    public void ReadyButton() {
        UGFR.Log.Debug("ReadyButton");
    }

}
