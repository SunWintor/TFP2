using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using Tutorial;

public class ProcedureSingleMode : ProcedureBase {
    protected override void OnEnter(ProcedureOwner procedureOwner) {
        base.OnEnter(procedureOwner);

        GameEntry.UI.OpenUIForm("Assets/GameMain/UI/SingleGame.prefab", "DefaultGroup", this);
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds) {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

    }
}
