namespace SingletonPattern.v4
{
    // Source: https://csharpindepth.com/articles/singleton
    //with this design, if we read from any other static field or member of this class, we are going to also initialize singleton instance.so if anything application references GREETING it will instantiate singleton
    //so its not as lazy as we would like
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();
        //C# static constructors run only once per app domain.good for implementing Singleton behaviour
        //static constructors are called when any static member of a type is referenced.this provides some degree of lazy instantiation.
        

        // reading this from anywhere will initialize the _instance
        public static readonly string GREETING = "Hi!";

        // Tell C# compiler not to mark type as beforefieldinit
        // (https://csharpindepth.com/articles/BeforeFieldInit)
        static Singleton()
        {//this ensures that we will not mark this class as beforefieldinit. which makes sure that it does not instantiate that singleton instance any erlier than possible.
        }

        //beforefieldinit is a hint to compiler uses to let it know static initializer can be called sooner.
        //This is the default if the type does not have an explicit static constructor.
        //adding explicit static constructor avoids having beforefieldinit applied. which helps make our singleton behaviour lazier.

        public static Singleton Instance 
        {
            get
            {
                Logger.Log("Instance called.");
                return _instance;
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
