using UGFR = UnityGameFramework.Runtime;
using GameMain;

public class SingleGame : UGFR.UIFormLogic {

    private static ProcedureSingleMode procedureSingleMode;

    protected override void OnOpen(object userData) {
        procedureSingleMode = (ProcedureSingleMode)userData;
        this.InternalSetVisible(true);
    }

}
