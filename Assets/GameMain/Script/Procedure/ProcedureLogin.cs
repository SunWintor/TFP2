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
         * У���û��Ƿ��Ѿ���¼������Ѿ���¼����ת����Ϸ����
         */
        private void LoginCheck() {
            if (User != null && User.Csrf != "") {
                // todo login
                // GameEntry.UI.CloseAllLoadedUIForms();
                // ChangeState<ProcedureLobby>(owner);
            }
        }

        /**
         * ������Ϸ
         */
        public void SingleMode() {
            ChangeState<ProcedureSingleMode>(owner);
        }

        /**
         * ��¼��ť�¼�
         */
        public void LoginButton() {

        }

        /**
         * ע�ᰴť�¼�
         */
        public void RegisterButton() {

        }

        /**
         * �򿪵�¼����
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
         * ��ע�ᴰ��
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
