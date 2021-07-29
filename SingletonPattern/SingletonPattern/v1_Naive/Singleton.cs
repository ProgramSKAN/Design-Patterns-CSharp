namespace SingletonPattern.v1
{
    // Bad code
    //naive approach
    //not thread safe : in multithreaded environment below if block can be reached by multiple threads concurrantly, resulting in multiple instantiations of singleton
#nullable enable
    public sealed class Singleton
    {
        private static Singleton? _instance;//nullable reference type >C#8   //#nullable enable required

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                // if(_instance==null){
                //     _instance=new Singleton();
                // }
                // return _instance;
                // OR
                return _instance ??= new Singleton();
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
