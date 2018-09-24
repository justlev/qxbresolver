# Qubits Resolver - Quantum Computing Simulation
#### A Generic, over-engineerd even, solution for resolving Quantum Computing Qubits
Includes best-practices, design patterns, unit tests and integration tests, documentation, etc.

## Technology: 
C# - .NET Core 2.0
Using a python helper utility for simulating a Quantum Computer

## Structure:
The solution contains 3 projects:

1. Resolver - .dll- library with all the logic that can be consumed by any type of consumer.
2. ResolverConsole - A test Console Application that consumes the resolver dll. Can easily be replaced with a WebServer.
3. ResolverTests (Contains Unit Tests and Integration Tests).

## Description:


I’ve tried to make this solution as generic as possible. All dependencies are injected, generics are used across the solution to allow different data types (What if user input is now a custom object? What if an int value can no longer hold the value of Coupling between elements?).

The architecture includes MVC pattern, Facade pattern, DI and IOC, and general SOLID principles.

The idea was that there is an API (IQubitsCalculationAPI) which has several lines of code that invoke the relevant components, which in their turn perform all the calculations.
The API.Resolve() method should be a simple set of instructions, hiding the complexity of the calculations.
Hence all the dependencies that are injected to the API.
Another solution is to use a Container that injects the dependencies itself, but then the implementation is bound to the container, which I do not want to happen.

I have noticed that the main thing that would change between different usecases, is the coupling and the bias. So, when there is a new usecase, it will be enough to implement just those two entities and inject them, and that’s it, the rest can be left untouched and it will work.
If a new script (or an embedded resolver) is provided, then we just need to implement the IQuantumResolver interface and inject it. 

The rest of the entities should be pretty straight forward. Facade to extract biases and couplings from the user’s input, an actual resolver that receives those biases and couplings and calculates the best qubits (IsakovResolver in our case), and finally a converter that puts the user’s input into groups based on the calculated qubits.


I’ve also implemented the IsakovWrapper python script in this solution for a couple of reasons:
To avoid a dependency on Python
To show how another use case can be integrated into the system.

If you run the program as is, it will run with the Challenge use case (Divide into groups with minimum connections between each other).