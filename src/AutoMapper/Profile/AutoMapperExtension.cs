using System;

namespace TianCheng.Model
{
    /// <summary>
    /// AutoMapper的扩展处理
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// 初始化对象映射关系
        /// </summary>
        public static void InitializeMappers()
        {
            var cfg = new AutoMapper.Configuration.MapperConfigurationExpression();

            foreach (Type proType in AssemblyHelper.GetTypeByInterface<IAutoProfile>())
            {
                cfg.AddProfile(proType);
            }

            AutoMapper.Mapper.Initialize(cfg);
        }

        /// <summary>
        /// 检验 Mapper 是否正确
        /// </summary>
        public static void AssertMapper()
        {
            try
            {
                AutoMapper.Mapper.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                CommonLog.Logger.Information(ex.Message);
            }
        }
    }
}
