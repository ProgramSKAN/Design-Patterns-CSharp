using System;

//BEST APPROACH
namespace SingletonPattern.v6
{
    // Source: https://csharpindepth.com/articles/singleton
    /*
     * Lazy<T> provides builtin support for lazy initialization. and prevent using nested class & checking if(_instance==null).
     * introduced in .net 4 2010 and used to implement singleton
     */
    public sealed class Singleton
    {
        // reading this will initialize the instance 
        //Lazy<T> is thread safe
        public static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return _lazy.Value;
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
