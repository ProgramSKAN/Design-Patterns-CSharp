# Command Pattern (Behavioral)

- Command > I am the command (AddToCartCommand)
- Receiver > The command runs me! (ShoppingCart)
- Invoker > I run & keep track of the commands (CommandManager)
- Cllient > I decide what command to schedule (Button)

#### Eg Commands

    AddToCartCommand
    ChangeQuantityCommand
    RemoveFromCartCommand
    RemoveAllFromCartCommand
    CheckoutCommand

- before every command run, it is check that it can be executed or not.
- Command pattern can easily be leveraged to allow undo or redo functionality.(eg: if application crashes and you start it again then we have a list of commands that we executed prior to application crashing.so can be re-executed to be in previous state)

* Command pattern adds complexty which might not always be desirable but we separated our concerns (eg:Console applicaiton in example no longer has to know about how to interact with repository.and with CommandManger there is a benifit of undoing method on our command)
* in Command Patterns , new commands can be introduced without modifying existing ones to avoid the rist of breaking other usages if pre-existing command
