using RelEcs;
using Undine.Core;

namespace Undine.RelEcs
{
    public class RelEcsContainer : EcsContainer
    {
        public World World { get; set; }
        public SystemGroup SystemGroup { get; set; }

        public RelEcsContainer()
        {
            World = new World();
            SystemGroup = new SystemGroup();
        }

        public override void AddSystem<A>(UnifiedSystem<A> system)
        {
            SystemGroup.Add(new RelEcsSystem<A>()
            {
                System = system,
                World = World
            });
        }

        public override void AddSystem<A, B>(UnifiedSystem<A, B> system)
        {
            SystemGroup.Add(new RelEcsSystem<A, B>()
            {
                System = system,
                World = World
            });
        }

        public override void AddSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            SystemGroup.Add(new RelEcsSystem<A, B, C>()
            {
                System = system,
                World = World
            });
        }

        public override void AddSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            SystemGroup.Add(new RelEcsSystem<A, B, C, D>()
            {
                System = system,
                World = World
            });
        }

        public override IUnifiedEntity CreateNewEntity()
        {
            return new RelEcsEntity()
            {
                World = World,
                EntityBuilder = World.Spawn()
            };
        }

        public override void DeleteEntity(IUnifiedEntity entity)
        {
            var entityToDespawn = entity as RelEcsEntity;
            if (entityToDespawn is not null)
            {
                World.Despawn(entityToDespawn.EntityBuilder.Id());
            }
        }

        public override Core.ISystem GetSystem<A>(UnifiedSystem<A> system)
        {
            return new RelEcsSystem<A>()
            {
                System = system,
                World = World
            };
        }

        public override Core.ISystem GetSystem<A, B>(UnifiedSystem<A, B> system)
        {
            return new RelEcsSystem<A, B>()
            {
                System = system,
                World = World
            };
        }

        public override Core.ISystem GetSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            return new RelEcsSystem<A, B, C>()
            {
                System = system,
                World = World
            };
        }

        public override Core.ISystem GetSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            return new RelEcsSystem<A, B, C, D>()
            {
                System = system,
                World = World
            };
        }

        public override void Run()
        {
            SystemGroup.Run(World);
        }
    }
}