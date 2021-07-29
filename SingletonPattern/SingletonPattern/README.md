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
