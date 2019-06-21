namespace TianCheng.Model
{
    /// <summary>
    /// 业务流程枚举
    /// </summary>
    public enum ProcessState
    {
        /// <summary>
        /// 未设置
        /// </summary>
        None = 0,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 1,
        /// <summary>
        /// 申请
        /// </summary>
        Apply = 2,
        /// <summary>
        /// 一审通过
        /// </summary>
        Review = 4,
        /// <summary>
        /// 一审拒绝
        /// </summary>
        ReviewDisagreed = 8,
        /// <summary>
        /// 二审通过
        /// </summary>
        Check = 16,
        /// <summary>
        /// 二审拒绝
        /// </summary>
        CheckDisagreed = 32,
        /// <summary>
        /// 三审通过
        /// </summary>
        Verify = 64,
        /// <summary>
        /// 三审拒绝
        /// </summary>
        VerifyDisagreed = 128,
        /// <summary>
        /// 数据发布
        /// </summary>
        Release = 256,
        /// <summary>
        /// 发布已取消
        /// </summary>
        Unrelease = 512,

        /// <summary>
        /// 启用
        /// </summary>
        Enable = 1024,
        /// <summary>
        /// 禁用
        /// </summary>
        Disable = 2048,

        /// <summary>
        /// 完成
        /// </summary>
        Complete = 4096,
        /// <summary>
        /// 申请禁用
        /// </summary>
        ApplyDisable = 8192
    }
}
