using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public static partial class ServiceTool
    {
        public interface ICoreModule
        {
            void Load(IServiceCollection collection);
        }
    }
}
