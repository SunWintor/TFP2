using GameFramework.Procedure;
using Tutorial;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain {
    public class ProcedureSplash : ProcedureBase {

        ProcedureOwner owner;

        protected override void OnEnter(ProcedureOwner procedureOwner) {
            base.OnEnter(procedureOwner);
            owner = procedureOwner;
            // ���ع�������
            GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Logo.prefab", "DefaultGroup", this);
        }

        public void ChangeToLogin() {
            GameEntry.UI.CloseAllLoadedUIForms();
            ChangeState<ProcedureLogin>(owner);
        }
    }
}
