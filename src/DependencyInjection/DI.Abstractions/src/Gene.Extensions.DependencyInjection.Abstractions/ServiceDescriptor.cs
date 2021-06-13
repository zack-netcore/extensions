using System;
using System.Collections.Generic;
using System.Text;

namespace Gene.Extensions.DependencyInjection.Abstractions
{
    public class ServiceDescriptor
    {
        public ServiceLifetime Lifetime { get; }

        public Type ServiceType { get; set; }

        public Type ImplementationType { get; set; }

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime) : this(serviceType, lifetime)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            this.ImplementationType = implementationType;
        }

        private ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            this.ServiceType = serviceType;
            this.Lifetime = lifetime;
        }

        public static ServiceDescriptor Transient<TServiceType, TImplementation>()
             where TServiceType : class
             where TImplementation : class, TServiceType
        {
            return Describe<TServiceType, TImplementation>(ServiceLifetime.Transient);
        }

        public static ServiceDescriptor Scoped<TServiceType, TImplementation>()
            where TServiceType : class
            where TImplementation : class, TServiceType
        {
            return Describe<TServiceType, TImplementation>(ServiceLifetime.Scoped);
        }

        public static ServiceDescriptor Singleton<TServiceType, TImplementation>()
            where TServiceType : class
            where TImplementation : class, TServiceType
        {
            return Describe<TServiceType, TImplementation>(ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Describe<TServiceType, TImplementation>(ServiceLifetime lifetime)
            where TServiceType : class
            where TImplementation : class, TServiceType
        {
            return Describe(typeof(TServiceType), typeof(TImplementation), lifetime);
        }

        public static ServiceDescriptor Describe(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationType, lifetime);
        }
    }
}
