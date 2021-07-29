namespace SingletonPattern.v2
{
    // Bad code
    // Source: https://csharpindepth.com/articles/singleton
    //this approch is thread safe but -ve performance impact because every use of the insatnce property will now incur the overhead of lock.

    //note : if you use lock always use dedicated private instance variable like 'padlock' not shared,public,static value that could be used by another lock elsewhere in application.
    //lock statements should be paired 1 for 1 to their loack statements.
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object padlock = new object();

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                lock (padlock) // this lock is used on *every* reference to Singleton
                {//this ensures that multiple threads need to synchronize and enter this block of code 1-by-1 ensuring 2 threads never create instance at same time.
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }

        private Singleton()
        {
            // cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
