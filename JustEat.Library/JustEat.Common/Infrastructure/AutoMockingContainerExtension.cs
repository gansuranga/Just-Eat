// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMockingContainerExtension.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the AutoMockingContainerExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Common.Infrastructure
{
    using System;
    
    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.ObjectBuilder;
    
    using Moq;

    /// <summary>
    /// The auto mocking container extension.
    /// </summary>
    public class AutoMockingContainerExtension : UnityContainerExtension
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        protected override void Initialize()
        {
            var strategy = new AutoMockingBuilderStrategy(Container);
            Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
        }

        /// <summary>
        /// Builder strategy for mocking.
        /// </summary>
        public class AutoMockingBuilderStrategy : BuilderStrategy
        {
            /// <summary>
            /// The container.
            /// </summary>
            private readonly IUnityContainer Container;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutoMockingBuilderStrategy"/> class. 
            /// Constructor
            /// </summary>
            /// <param name="container">
            /// </param>
            public AutoMockingBuilderStrategy(IUnityContainer container)
            {
                this.Container = container;
            }

            /// <summary>
            /// The pre build up.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            public override void PreBuildUp(IBuilderContext context)
            {
                var key = context.OriginalBuildKey;

                // If the interface is not registered
                if (key.Type.IsInterface && !this.Container.IsRegistered(key.Type))
                {
                    context.Existing = CreateDynamicMock(key.Type);
                }
            }

            /// <summary>
            /// Create a dynamic mock object. 
            /// </summary>
            /// <param name="type">Type</param>
            /// <returns>Object Type</returns>
            private static object CreateDynamicMock(Type type)
            {
                var genericMockType = typeof(Mock<>).MakeGenericType(type);
                var mock = (Mock)Activator.CreateInstance(genericMockType);
                return mock.Object;
            }
        }
    }

}
