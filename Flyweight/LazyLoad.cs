using System;

namespace Flyweight
{
    public class LazyLoad<T> where T : class
    {
        private readonly Func<T> lazyLoadInstance;
        private T actualInstance;

        public LazyLoad(Func<T> lazyLoadInstance)
        {
            this.lazyLoadInstance = lazyLoadInstance;
        }

        public T Instance
        {
            get
            {
                actualInstance = actualInstance ?? lazyLoadInstance();
                return actualInstance;
            }
        }

        public bool IsCreated
        {
            get { return actualInstance != null; }
        }
    }
}