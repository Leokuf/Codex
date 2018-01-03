------------------------------
SECTION 1
------------------------------

------------------------------
Web resources:
------------------------------
- Programming Guide (Official): https://docs.microsoft.com/en-us/dotnet/csharp/index
- https://mva.microsoft.com/en-US/training-courses/programming-in-c-jump-start-14254?l=MqbQvzSfB_1500115888
- https://blogs.msdn.microsoft.com/dboyle/2013/03/27/exam-70-483-programming-in-c-5-0/
- https://skillvalue.com
- https://github.com/quozd/awesome-dotnet

------------------------------
Overview: Object Oriented Programming, Managed Languages and C#
------------------------------

Managed language: depend on services provided by a runtime environment.
Managed code is executed by the Common Language Runtime(CLR).

CLR provides features:
1. Automatic memory management
2. Exception Handling
3. Standard Types
4. Security

Type: Foundational building block with Metadata.
Object: The base of all types.

Three categories of type:
1. Value types - these directly store values
2. Reference types (i.e.: objects) store a reference to data
3. Pointer types - Only available in unsafe code.

------------------------------
C# & Encapsulation:
------------------------------
- Encapsulation means to create a boundary around an object to separate its external (public) behavior from its internal (private) implementation.
- Consumers of an object should only concern themselves with what an object does, not how it does it.
C# supports encapsulation via:
1. Unified Type System: Identified all universal and repetitive types in the run time.
2. Classes and Interfaces
3. Properties, Methods and Events

------------------------------
C# & Inheritance:
------------------------------
C# implements Inheritance in two ways:
1. A class may inherit from a single base class
2. A class may implement zero or more Interfaces.

------------------------------
C# & Polymorphism:
------------------------------
- A class can be used as its own type, cast to any base type or interface types it implements.
- Objects may methods as virtual; virtual methods may be overridden in a derived type. These are executed instead of the base implementation.

------------------------------
Developer Productivity:
------------------------------
Examples:
- var - simplifies variable definition while retaining strong typing.
- LINQ - language integrated query
- Lambdas - a further refinement of anonymous methods used extensively in LINQ.

------------------------------
C# Syntax:
------------------------------
Indentifiers are names of classes, methods, variables, and so on:
 - Lion, Sound, MakeSound(), Console, WriteLine()
Keywords are compiler reserved words:
- public, class, string, get, set, void


------------------------------
Example Syntax:
------------------------------
~~~~
public class Lion()
{
    public string Sound {get; set;}
    public void MakeSound(){
        Console.WriteLine(Sound);
    }	
}
~~~~
------------------------------
Code Decoration:
------------------------------

Attributes 
- Associate additional metadata to types and members
- Discoverable at runtime via reflection

Does C# still need comments?
- Block comments
- Single line comments
- XML documentation
-- Can be extracted into separate XML files during compilation
-- Can be used to generate formal documentation

------------------------------
Anonymous Types:
------------------------------

Types without a design-time definition
- used extensively with LINQ
Compiler inferred types
Is it portable?


------------------------------
Extension Methods:
------------------------------
Extension methods extend types without altering them.
- Especially useful for extending classes that are not yours or are sealed.
They are declared as static methods in a static class.
The first parameter has the this modifier.
The first parameter's type is the type being extended.

------------------------------
Dynamics:
------------------------------
- Instructs the compiler to ignore type checking at compile-time.
- Defers type checking until runtime
- Simplifies interaction with COM interfaces / un-typed, external objects



------------------------------
SECTION 2: Constructing Complex Types - Object Interfacess and Inheritance
------------------------------

------------------------------
Classes and Structs
------------------------------
- A class or struct defines the template for an object.
- A class represents a reference type.
- A struct represents a value type.
- Reference and value imply memory strategies.

------------------------------
When to use Structs
------------------------------
Use structs if:
- instances of the type are small
- the struct is commonly embedded in another type
- the struct logically represents a single value
- the values don't change (immutable)
- It is rarely "boxed"

------------------------------
Class
------------------------------
A class defines a reference type (or object).
Classes can optionally be declared as:
-- static - cannot ever be instantiated
-- abstract - incomplete class; must be completed in a derived class
-- sealed -cannot be inherited from

Example:
~~~~
public class Animal {
}
~~~~

------------------------------
SECTION 3: Controlling Progammatic Flow - Manipulating Types and Strings
------------------------------
Selection Statements: If
- Selection statements evaluate Boolean expressions and direct execution
- If statements can be nested within other if statements.

//use braces to encapsulate blocks
~~~~
if (value == 1)
{
    Console.WriteLine("One");
    DoSomethingElse();
}
// else if is used to exit the Selection Statement
else if (value == 2)
{
    Console.WriteLine("Two");
    DoSomethingElse();
}
else
{
    Console.WriteLine("Other");
    DoSomethingElse();
}
~~~~
---
Selection Statements :ternary
- The ternary or conditional operator can be used as if statement shorthand.
~~~~
if (value == 1)
{
    Console.WriteLine("One");
}
else
{
    Console.WriteLine("Not One");
}

//ternary
Console.WriteLine(value == 1 ? "One" : "Not One");
~~~~

Iteration Statements: while, do-while
- while and do-while statements execute a body of code if the expression evaluates to true.
-- **while** evalutes the expression before executing the body, so the body may execute 0 or more times.
-- **do-while** evaluates the expression after the first execution of the body, so the body executes at least once.
~~~~
var loopCounter = 0;
while (loopCounter > 0)
{
    Console.WriteLine("This will not execute!");
}

do
{
    Console.WriteLine("This will execute once!");
} while (loopCounter > 0);
~~~~
---

Iteration Statements: For
- *for loops* are similar to *while loops*
- *for loops* include clause that execute before the loop begins and after every iteration:
-- Initialization clause - typically used to initialize one or more loop variables
-- Iteration clause - typically used to update the loop variable
~~~~
var string = new[]
    {
        "String 1", "String 2", "String 3
    };
for (int i=0; i < strings.Length; i++)
{
    Console.WriteLine(strings[i]);
}
~~~~

------------------------------
SECTION 4: Code Reflection and Information - Working with Garbage Collection
------------------------------
Reflection:
- Inspects type metadata at runtime
- The type metadata contains information such as: 
-- The type Name
-- The containng Assembly
-- Constructors
-- Properties
-- Methods
-- Attributes
- This data can be used to create instances, access values and execute methods dynamically at runtime.

How to get Type data:
- Two methods
(1) Staically at compile time
(2) Dynamically at runtime

~~~~
var dog = new Dog { NumberOfLegs = 4 };

// At compile time
Type t1 = typeof (Dog);

// At runtime
Type t2 = dog.GetType();

// output: Dog
Console.WriteLine(t2.Name);

// output: After002, Version=1.0.0.0,
//  Culture=neutral, PublicKeyToken=null
Console.WriteLine(t2.Assembly);
~~~~

How to create an instance of a Type:
- Two methods to dynamically instantiate a type:
(1) Activator.CreateInstance
(2) Calling Invoke on a ConstructorInfo object (advanced scenarios)
	
~~~~
var newDog =
    (Dog)Activator.CreateInstance(typeof(Dog));

var genericDog = 
    Activator.CreateInstance<Dog>();

// uses default constructor
// with no defined parameters

var docConstructor =
    typeof (Dog).GetConstructors()[0];

var advancedDog =
    (Dog)dogConstructor.Invoke(null);
~~~~

Accessing a Property
~~~~
void Property()
{
    var horse = new Animal() { Name = "Ed" };
    var type = horse.GetType();
    var property = type.GetProperty("Name");
    var value = property.GetValue(horse, null);
    // value == "Ed"
}

public class Animal
{
    public string Name { get; set; }
}
~~~~

Invoking a Method
~~~~
void Method()
{
    var horse = new Animal();
    var type = horse.GetType();
    var method = type.GetMethod("Speak");
    var value = (string)method.Invoke(horse, null);
    //value == "Hello"
}

public class Animal
{
    public string Speak() { return "Hello"; }
}
~~~~

Garbage Collection:
- Garbage collection is automatic memory managemnt.
- De-referenced objects (orphans) are not collected immediately but periodically.
-- Many factors influence Garbage Collection frequency.
-- Not all orphans are collected at the same time.
- Garbage Collection is computationally expensive.

Forcing Garbage Collection
- In most cases, let the Garbage Collector do its thing.
- For a periodic activity it may make sense to force the collector to run:
-- Windows Service

~~~~
GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();
~~~~

Disposable Object
- Some objects need explicit code to release resources.
- The IDisposable interface marks taht these types implement the Dispose method.
- The simple dispose pattern works well for simple scenarios and sealed types.
-- Use the advanced pattern in most cases.

~~~~
interface IDisposable
{
    void Dispose();
}

public class Demo : IDisposable
{
    public void Dispose()
    {
        // release resources
    }
}
~~~~

Advanced Dispose Pattern
- Use for any non-trivial disposable object.

~~~~
public class AdvancedDemo : IDisposable
{
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            //release managed resources
        }
        // release unmanaged resources
    }

    ~Advanced Demo()
    {
        Dispose(false);
    }
}
~~~~
-------------------------------
static void Main(string[] args)
-------------------------------
static: The static keyword tells us that this method should be accessible without instantiating the class.
void: tells us what the method should return.
Main: the name of the method.
arg: a set of arguments can be specified within a set of parentheses.
string: the type of argument (an array of strings).

------------------------------
Data types
------------------------------
bool - can be false or true
int - data type for storing numbers without decimals.
string - used for storing text. C# strings are immutable, ie. they can't be changed after being created. If a string is changed, a new string is returned rather than modifying the original string.
char - used for storing a single character.
float - one of the data types used to store numbers which may or may not contain decimals.

------------------------------
Variables
------------------------------
~~~~
<visibility> <data type> <name> = <value>; 
private string name = "Colin McCaleb";
~~~~
------------------------------
Example program:
------------------------------
	
~~~~

using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "John";
            string lastName = "Doe";

            Console.WriteLine("Name: " + firstName + " " + lastName);

            Console.WriteLine("Please enter a new first name:");
            firstName = Console.ReadLine();

            Console.WriteLine("New name: " + firstName + " " + lastName);

            Console.ReadLine();
        }
    }
}
	
~~~~

------------------------------
End Program
------------------------------
