namespace TianCheng.Model
{
    /// <summary>
    /// 本接口用来标明程序集中那些对象之间需要AutoMapper , 在程序加载的时候方便自动处理不同程序集中的AutoMapper信息
    /// </summary>
    public interface IAutoProfile
    {
        /// <summary>
        /// 注册
        /// </summary>
        void Register();
    }
}
