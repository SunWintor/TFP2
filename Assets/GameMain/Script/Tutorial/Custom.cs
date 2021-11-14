using UnityEngine;

namespace Tutorial {
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour {
        /// <summary>
        /// 获取用户信息。
        /// </summary>
        public static UserInfo User {
            get;
            private set;
        }

        /// <summary>
        /// 获取游戏流程信息。
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
            // 将来在这里注册自定义的调试器
        }
    }
}