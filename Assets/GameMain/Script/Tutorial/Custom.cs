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

        private static void InitCustomComponents() {
        }

        private static void InitCustomDebuggers() {
            // ����������ע���Զ���ĵ�����
        }
    }
}