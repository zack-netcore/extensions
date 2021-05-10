using System;
using System.Collections.Generic;
using System.Text;

namespace Kevin.Extensions.DependencyInjection.Abstractions
{
    public enum ServiceLifetime
    {
        /// <summary>
        /// 单例
        /// </summary>
        Singleton,

        /// <summary>
        /// 范围
        /// </summary>
        Scoped,

        /// <summary>
        /// 瞬时
        /// </summary>
        Transient
    }
}
