using GameFramework.Procedure;
using Tutorial;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain {
    public class ProcedureSplash : ProcedureBase {

        private int logoUI;

        protected override void OnEnter(ProcedureOwner procedureOwner) {
            base.OnEnter(procedureOwner);
            // 加载过场动画
            logoUI = GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Logo.prefab", "DefaultGroup", this);
            UnityGameFramework.Runtime.Log.Debug("logoUI " + logoUI);
        }

        public void ChangeToLogin() {
            GameEntry.UI.CloseUIForm(logoUI);
            ChangeState<ProcedureLogin>(GameEntry.ProcedureInfo.owner);
        }
    }
}
