using RelEcs;
using Undine.Core;
using RelEcsSystem = RelEcs.ISystem;

namespace Undine.RelEcs
{
    public class RelEcsSystem<A> : Core.ISystem, RelEcsSystem
         where A : struct
    {
        public UnifiedSystem<A> System { get; set; }
        public World World { get; set; }
        public void ProcessAll()
        {
            Run(World);
        }

        public void Run(World world)
        {
            var query = world.Query<RelEcsComponentWrapper<A>>().Build();
            foreach (var aComponent in query)
            {
                System.ProcessSingleEntity(0, ref aComponent.Value);
            }
        }
    }
    public class RelEcsSystem<A, B> : Core.ISystem, RelEcsSystem
         where A : struct
         where B : struct
    {
        public UnifiedSystem<A, B> System { get; set; }
        public World World { get; set; }
        public void ProcessAll()
        {
            Run(World);
        }

        public void Run(World world)
        {
            var query = world.Query<RelEcsComponentWrapper<A>, RelEcsComponentWrapper<B>>().Build();
            foreach (var (aComponent, bComponent) in query)
            {
                System.ProcessSingleEntity(0, ref aComponent.Value, ref bComponent.Value);
            }
        }
    }
    public class RelEcsSystem<A, B, C> : Core.ISystem, RelEcsSystem
         where A : struct
         where B : struct
         where C : struct
    {
        public UnifiedSystem<A, B, C> System { get; set; }
        public World World { get; set; }
        public void ProcessAll()
        {
            Run(World);
        }

        public void Run(World world)
        {
            var query = world.Query<RelEcsComponentWrapper<A>, RelEcsComponentWrapper<B>, RelEcsComponentWrapper<C>>().Build();
            foreach (var (aComponent, bComponent, cComponent) in query)
            {
                System.ProcessSingleEntity(0, ref aComponent.Value, ref bComponent.Value, ref cComponent.Value);
            }
        }
    }
    public class RelEcsSystem<A, B, C, D> : Core.ISystem, RelEcsSystem
         where A : struct
         where B : struct
         where C : struct
         where D : struct
    {
        public UnifiedSystem<A, B, C, D> System { get; set; }
        public World World { get; set; }
        public void ProcessAll()
        {
            Run(World);
        }

        public void Run(World world)
        {
            var query = world.Query<RelEcsComponentWrapper<A>, RelEcsComponentWrapper<B>, RelEcsComponentWrapper<C>, RelEcsComponentWrapper<D>>().Build();
            foreach (var (aComponent, bComponent, cComponent, dComponent) in query)
            {
                System.ProcessSingleEntity(0, ref aComponent.Value, ref bComponent.Value, ref cComponent.Value, ref dComponent.Value);
            }
        }
    }
}
