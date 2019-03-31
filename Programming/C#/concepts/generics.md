# C# Generics

## Generic type
* Allow us to define a variable data type.
* We define a typed parameter (T below)

### Single Generic parameter
```
public class OperationResult<T>
{
    public OperationResult()
    {
    }

    public OperationResult(T result, string message ) : this()
    {
        this.Result = result;
        this.Message = message;
    }

    public T Result { get; set; }
    public string Message { get; set; }
}
```

### Multiple Generic parameters
```
public class OperationResult<T, V>
{
    public OperationResult()
    {
    }

    public OperationResult(T result, V message ) : this()
    {
        this.Result = result;
        this.Message = message;
    }

    public T Result { get; set; }
    public V Message { get; set; }
}
```

* Use generics to build reusable, type-neutral classes. Avoid using generics when not needed.
* Use T as the type parameter for classes with one type parameter. Avoid using single-letter names when defining multiple type parameters. Use a descriptive naame instead.
* Prefix descriptive type parameter names with T

### Using a Generic Class
```
public class OperationResult<T>
{
    public OperationResult()
    {
    }

    public OperationResult(T result, string message ) : this()
    {
        this.Result = result;
        this.Message = message;
    }

    public T Result { get; set; }
    public string Message { get; set; }
}
// you can use either of these to call class
var operationResult = new OperationResult<bool>(success, orderText);
var operationResult = new OperationResult<decimal>(value, orderText);

```

# Defining Generic Methods

```
public T RetrieveValue<T>(string sql, T defaultValue)
```

* Use generic methods to build reusable, type-neutral methods. Avoid generics when not needed.
* Use T as the type parameter for methods with one type parameter.
* Prefix descriptive type parameter names with T
```
public TReturn RetValue<TReturn, TParameter>
    (string sql, TParameter sqlParameter)
```
* Define the type parameter(s) on the method signature, not the class signature.
```
public T RetrieveValue<T>(string sql, T defaultValue)
{
    // Call the database to retrieve the value
    // If no value is returned, return the default value
    T value = defaultValue;

    return value;
}
```
### Generic Constraints
```
// Use struct when constraining T to Value type
// Value type variables can't be null by default. Value type variables directly contain their data. Value types include integral types (integer numeric types and the char type), Floating-point types, and bool.
where T : struct

// Use class when constraining T to reference type
// Reference type variables store references to their data (objects). Reference types include class, delegate, dynamic, interface, object, string.
where T : class

// Use new() when constraining T to type with parameterless constructor
where T : new

// Use Vendor when constraining T to be or derive from Vendor
where T : Vendor

// Use IVendor when constraining T to be or implement the IVendor interface
where T : IVendor
```

##### Generic Constraint Syntax
```
public class OperationResult<T> where T : struct
```
