using RelEcs;
using System;
using System.Collections.Generic;
using System.Text;
using Undine.Core;

namespace Undine.RelEcs
{
    public class RelEcsEntity : IUnifiedEntity
    {
        public EntityBuilder EntityBuilder { get; set; }
        public World World { get; set; }

        public void AddComponent<A>(in A component) where A : struct
        {
            EntityBuilder.Add(new RelEcsComponentWrapper<A>() { Value = component });
        }

        public ref A GetComponent<A>() where A : struct
        {
            return ref World.GetComponent<RelEcsComponentWrapper<A>>(EntityBuilder.Id()).Value;
        }

        public void RemoveComponent<A>() where A : struct
        {
            EntityBuilder.Remove<RelEcsComponentWrapper<A>>();
        }
        public bool HasComponent<A>() where A : struct
        {
            return World.HasComponent<RelEcsComponentWrapper<A>>(this.EntityBuilder.Id());
        }
    }
}