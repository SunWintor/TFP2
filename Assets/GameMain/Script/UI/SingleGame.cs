using UGFR = UnityGameFramework.Runtime;
using GameMain;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
    }

    /**
     * 关闭
     */
    public void CloseButton() {
        UGFR.Log.Debug("CloseButton");
    }

    /**
     * 加
     */
    public void AddButton(int count) {
        UGFR.Log.Debug("AddButton" + count);
    }

    /**
     * 确认
     */
    public void ReadyButton() {
        UGFR.Log.Debug("ReadyButton");
    }

}
