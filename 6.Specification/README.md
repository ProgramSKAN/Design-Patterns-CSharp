# Specification Pattern (Behavioual)

- its hepls avoid domain knowledge duplication(ie, adheres to DRY principle).reduces technical debt.
- Declarative approach , which intern increases mantainability of codebase.

* basic idea with this pattern is , when you have some piece of domain knowledge, you can encapsulate it to single unit (Specifictaion) an then reuse in different parts of codebase.

## 3 Use Cases of this pattern

1. In-memory validation. ie: when you need to check if an object you have fits some criteria.This is useful in scenarios with validating in common input requests from users or 3rd party systems.
2. Retriving data from Database. ie: finding records that match the specification.
3. Construction-to-order. ie:creating new objects that comply with criteria.this is helpful in scenarios where you don't care about actual content of the objects but still need themto have certain attributes.

- first 2 usecases are most common
