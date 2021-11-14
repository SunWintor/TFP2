using UnityEngine;

namespace Tutorial {
    /// <summary>
    /// ��Ϸ��ڡ�
    /// </summary>
    public partial class GameEntry : MonoBehaviour {
        /// <summary>
        /// ��ȡ�û���Ϣ��
        /// </summary>
        public static UserInfo User {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ��Ϸ������Ϣ��
        /// </summary>
        public static GameProcedureInfo ProcedureInfo {
            get;
            private set;
        }

        private static void InitCustomComponents() {
            User = new UserInfo();
            ProcedureInfo = new GameProcedureInfo();
        }

        private static void InitCustomDebuggers() {
            // ����������ע���Զ���ĵ�����
        }
    }
}