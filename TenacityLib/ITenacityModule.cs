using System.Collections.Generic;

namespace TenacityLib
{
    public interface ITenacityModule
    {
        string Name { get; }
        string Description { get; }
        bool Enabled { get; set; }
        string Tab { get; }
        List<TenacityOption> Options { get; set; }
        void Start();
        void Cleanup();
    }
}
