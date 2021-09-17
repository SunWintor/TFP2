using GameFramework.Procedure;
using Tutorial;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain {
    public class ProcedureLogin : ProcedureBase {

        private UserInfo User;
        private ProcedureOwner owner;

        protected override void OnEnter(ProcedureOwner procedureOwner) {
            base.OnEnter(procedureOwner);
            owner = procedureOwner;
            User = GameEntry.User;
            OpenLoginUI();
        }

        /**
         * 校验用户是否已经登录，如果已经登录则跳转到游戏大厅
         */
        private void LoginCheck() {
            if (User != null && User.Csrf != "") {
                // todo login
                GameEntry.UI.CloseAllLoadedUIForms();
                // ChangeState<ProcedureLobby>(owner);
            }
        }


        public void SingleMode() {
            // ChangeState<SingleMode>(owner);
        }

        /**
         * 登录按钮事件
         */
        public void LoginButton() {

        }

        /**
         * 注册按钮事件
         */
        public void RegisterButton() {

        }

        /**
         * 打开登录窗口
         */
        private void OpenLoginUI() {
            LoginCheck();
            GameEntry.UI.CloseAllLoadedUIForms();
            GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Login.prefab", "DefaultGroup");
        }

        /**
         * 打开注册窗口
         */
        private void OpenRegisterUI() {
            GameEntry.UI.CloseAllLoadedUIForms();
            GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Register.prefab", "DefaultGroup");
        }
    }
}
