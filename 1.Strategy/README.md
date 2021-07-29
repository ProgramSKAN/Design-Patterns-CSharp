# STRATEGY Pattern (Behavioural)

- using STRATEGIES to decouple part of application. here eg: Order.cs

- Extensible : Adding additional stategies should not affect existing implementation.
  eg: adding SmsInvoiceStrategy without affecting email,file,printOndemand Invoice Strategy

- Testable : Since this leverages Inteface instead of concrete implementations, it becomes lot easier to write automayed tests for project.(like mocked strategy)

- STRATEGY Pattern sometime also called POLICY Pattern.
  eg: way to work with different shipping providers.support providers like DHL,FEDx, US Postal service,UPS,Swedish Postal Service depending on order is being sent to sweden or not.All this different requiremennts and policies and validation need to be in the strategies.

Note: Whenever you can pass or inject an interface which changes the strategy or behaviour for how to compute someting, you can leverage STRATEGY Pattern.
STRATEGY pattern allows to replace functionality at runtime based on the behavious of the users.

    1.one of the most commonly used patterns
    2.Decouple the context and concrete implementation
    3.Allows clener implementation in the context
    4.Easily extend with additional strategies with affecting current implementations
    5.Makes testing easier.You can write mocked implementations to inject
