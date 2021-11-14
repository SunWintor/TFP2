using GameFramework.Procedure;
using Tutorial;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityEngine;

namespace GameMain {
    public class ProcedureLogin : ProcedureBase {

        private UserInfo User;
        private ProcedureOwner owner;
        private int loginUI;
        private int registerUI;
        private Canvas loginLogic;
        private Canvas registerLogic;

        protected override void OnEnter(ProcedureOwner procedureOwner) {
            base.OnEnter(procedureOwner);
            owner = procedureOwner;
            User = GameEntry.User;
            OpenLoginUI(null);
        }

        /**
         * 校验用户是否已经登录，如果已经登录则跳转到游戏大厅
         */
        private void LoginCheck() {
            if (User != null && User.Csrf != "") {
                // todo login
                // GameEntry.UI.CloseAllLoadedUIForms();
                // ChangeState<ProcedureLobby>(owner);
            }
        }

        /**
         * 单人游戏
         */
        public void SingleMode() {
            ChangeState<ProcedureSingleMode>(owner);
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
        public void OpenLoginUI(Canvas logic) {
            if (logic != null) {
                registerLogic = logic;
            }
            LoginCheck();
            if (loginUI == 0) {
                loginUI = GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Login.prefab", "DefaultGroup", this);
                return;
            } 
            if (registerLogic != null) {
                registerLogic.sortingOrder = -1;
            }
            if (loginLogic != null) {
                loginLogic.sortingOrder = 1;
            }
        }

        /**
         * 打开注册窗口
         */
        public void OpenRegisterUI(Canvas logic) {
            loginLogic = logic;
            if (registerUI == 0) {
                registerUI = GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Register.prefab", "DefaultGroup", this);
                return;
            }
            if (registerLogic != null) {
                registerLogic.sortingOrder = 1;
            }
            if (loginLogic != null) {
                loginLogic.sortingOrder = -1;
            }
        }
    }
}
