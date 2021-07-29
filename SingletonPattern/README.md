# SINGLETON Pattern (Behavioural)

- A Singleton is a class designed to only ever have one instance.The class itself is responsible for this.

* Eg: Access to file system, Access to shared network resource (scanner,printer), etc like expensive one time configuration instance.

* used where cost of creating new instance is expensive.for performance reasons it is only desirable to incur the cost of instance creation when the instance is first requested.this is called Lazy instantiation or creation.

*

### Features

---

- At any time, only 0 or 1 instance of siingletone class exixts in the application
- Singleton classes are created without parameters.(use may be Fatory if needed)
- Assume lazy instantiation as default.(created only when requested). but its possible to created instance in the beginning and use it for life of the app

* Singleton class contains single private parameterless constructor.Because of this subclassing isn't allowed. To enforce this intent and help optimise JIT compiler Singleton class should be marked as 'sealed'
* A private static method holds the only refernece to the instance in Singleton class.A public static method provides access to this field
