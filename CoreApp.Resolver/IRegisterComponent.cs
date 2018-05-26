using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Resolver
{
    /// <summary>
    /// Responsible for registering types in unity configuration by implementing IComponent
    /// </summary>
    public interface IRegisterComponent
    {
        /// <summary>
        /// Register type method
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        /// <summary>
        /// Register type with container controlled life time manager
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
        void RegisterTypeWithInjectedConstructor<TFrom, TTo>(string param) where TTo : TFrom;
        void RegisterTypeWithInjectedFactory<TFrom>(object obj);
        void RegisterTypeWithTransientLifetimeManager<TFrom, TTo>() where TTo : TFrom;
    }
}
