# Singleton Pattern

- A Singleton class is designed to only ever have one instance created.
- Singleton pattern makes the class itself responsible for enforcing singleton behaviour

* Lazy<T> or IOC containers is the better approach to implement it in C#

#### Singleton Pattern is Antipattern because

- direct static use of code instead of interface.Which is difficult to test due to shared state.
- doesn't follow separation of conserns & single responsibility principle
- if you implement >1 singleton, you'are going to have duplicate of all logic to enforce singleton behaviour.This means you violating DRY(don't repeat yourself) princple.

### Singleton vs Static class

---

#### Singleton Class

- can implement interface
- can be passed as an arguments to methods(so can use strategy design pattern and dependency injection)

* can be assigned to variables
* singleton instance can use polymorphism
* can have state
* can be serialized.they can be stored, transferred, transmitted over the wire

#### Static Class

- No Interfaces(these are just collentions of static members, functions)

* cannot be passed as arguments to methods (so cannot use strategy design pattern and dependency injection)
* cannot be assigned to variable
* static instance cannot use polymorphism.these are purly procedural.
* do not typically access any state aside from global state
* no support for serialization

## Singleton Behaviour using containers/Inversion of Control/dependency Inversion Containers/IoC/DI Containers

---

- these are FACTORIES on steroids
- classes request dependencies via constructor

* classes should follow explicit dependencies principle. ie, classes should not have any hidden dependencies
* container manages abstraction implementation mapping
* container manages instance lifetime
* eg: in .NetCore services.AddTransient,AddSingleton,AddScoped

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
