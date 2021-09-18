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
         * У���û��Ƿ��Ѿ���¼������Ѿ���¼����ת����Ϸ����
         */
        private void LoginCheck() {
            if (User != null && User.Csrf != "") {
                // todo login
                GameEntry.UI.CloseAllLoadedUIForms();
                // ChangeState<ProcedureLobby>(owner);
            }
        }

        /**
         * ������Ϸ
         */
        public void SingleMode() {
            // ChangeState<ProcedureSingleMode>(owner);
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
        public void OpenLoginUI() {
            LoginCheck();
            GameEntry.UI.CloseAllLoadedUIForms();
            GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Login.prefab", "DefaultGroup");
        }

        /**
         * ��ע�ᴰ��
         */
        public void OpenRegisterUI() {
            GameEntry.UI.CloseAllLoadedUIForms();
            GameEntry.UI.OpenUIForm("Assets/GameMain/UI/Register.prefab", "DefaultGroup");
        }
    }
}