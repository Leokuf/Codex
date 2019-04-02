# Events, Delegates and Event Handlers

- Event Raiser and Event Handler are connected with a Delegate.

- Event Args is the data sent from Event Raiser to Event handler(Args can be one or more properties)

## What is an Event? 
Events are notifications. Play a central role in the .NET framework. Provide a way to trigger notifications from end users or from objects.

## The Role of Events
[ button ]-> [ click event ] -> [ delegate ] -> [ method handles click event ]
- Events single the occurrence of an action/notification
- Objects that raise events don't need to explicitly know the object that will handle the event
- Events pass EventArgs (event data)

## The Role of Delegates
- The delegate is the glue between the Event and the Event Handler

## What is a Delegate?
- A delegate is a specialized class often called a "Function Pointer"
- The glue/pipeline between an event and an event handler.
- Based on a MulticastDelegate base class
- Delegates are a pipeline
- Delegates route data from point A to point B

## What is an Event Handler
- Event handler is responsible for receiving and processing data from a delegate
- Normally receives to parameters: (1) Sender (2) EventArgs
- EventArgs responsible for encapuslating event data.
- Event Handler is responsible for accessing data passed by a delegate.

~~~
public void btnSubmit_Click(object sender, EventArgs e) {
    // Handling of button click occurs here
}
~~~

## Demo: Events, Delegates, and Event Handlers
- Windows Form app
~~~
// Form1.cs

namespace BasicWindowsEvents
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CountriesComboBox_SelectIndexChanged(object sender, EventArgs e) {
            MessageBox.Show("Current index " + CountriesComboBox.SelectedIndex.ToString())
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click me");
        }
    }
}

~~~

## Creating Delegates, Events and EventArgs
- Custom delegates are defined using the delegate keyword:
~~~
public delegate void WorkPerformedHandler(int hours, WorkType workType);
~~~

Delegate is a bin. The pipeline dumps into the bin. We define the data that the pipeline can handle in the method.

The delegate signature must be mimicked by a handler method:

public delegate void WorkPerformedHandler(int hours, WorkType workType);


### Creating a Delegate Instance

~~~
// Delegate
public delegate void WorkPerformedHandler(int hours, WorkType workType);

// Delegate Instance
WorkPerformedHandler del1 =
    new WorkPerformedHandler(WorkPerformed1);

// Invoke del1
del1(5, WorkType.Golf);


// Handler
static void WorkPerformed1(int hours, WorkType workType)
{
    Console.WriteLine("WorkPerformed1 called");
}
~~~

- For decompiling code, download ILSpy (http://www.ilspy.net)

## Handling Events

The delegate signature must be mimicked by a handler method.

~~~
public delegate void WorkPerformedHanlder(object sender, WorkPerformedEventArgs e);

public void Manager_WorkPerformed(object sender, WorkPerformedEventArgs e) {


}
~~~

The += operator is used to attach an event to an event handler:

~~~
var worker = new Worker();
// attach to event through delegate
worker.WorkPerformed +=
    new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);


void worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
{
    Console.WriteLine(e.Hours.ToString());
}
~~~

Delegate Inference: 
~~~
var worker = new Worker();
// Compiler will "infer" the delegate
worker.WorkPerformed += worker_WorkPerformed;

void worker_WorkPerformed(object sender, WorkPerformedHandler e)
{
    Console.WriteLine(e.);
}
~~~


## Lambdas, Action<T> and Func<T, TResult>

### Lambdas and Delegates

#### Anonymous Methods in Action
~~~
SubmitButton.Click += delegate(object sender, EventArgs e)
{
    MessageBox.Show("Button Clicked");
};
~~~

#### Understanding Lambda Expressions
~~~
// Inline Method Parameters w/ Lambda Operator
SubmitButton.Click += (s, e) => MessageBox.Show("Button CLicked");
~~~

#### Assigning a Lambda to a Delegate
Lambda expressions can be assigned to any delegate

~~~
delegate int AddDelegate(int a, int b);

static void Main(string[] args){
    AddDelegate ad = (a, b) => a + b;
    int result = ad(1,1); // result = 2
}
~~~

#### Handling Empty Prameters
Delegates that don't accept any parameters can be handled using lambdas:

~~~
delegate bool LogDelegate();

static void Main(string[] args)
{
    LogDelegate ld = () =>
    {
        UpdateDatabase();
        WriteToEventLog();
        return true;
    };
    bool status = ld();
}
~~~

#### Using Action<T>

The .NET framework provides several different delegates that provide flexible options;
- Action<T> - Accepts a single parameter and returns no value.
- Func<T,TResult> - Accepts a single parameter and returns a value of type TResult

Action<T> can be used to call a method that accepts a single parameter of type T:
~~~
public static void Main(string[] args)
{
    Action<string> messageTarget;
    if (args.Length > 1) messageTarget = ShowWindowsMessage;
    else messageTarget = Console.WriteLine;
    messageTarget("Invoking Action!");
}

private static void ShowWindowsMessage(string message)
{
    MessageBox.Show(message);
}
~~~

#### Using Func<T,TResult>

Func<T,Tresult> supports a single parameter (T) and returns a value (TResult):

~~~
public static void Main(string[] args)
{
    Func<string, bool> logFunc;
    if (args[0] == "EventLog") logFunc = LogToEventLog;
    else logFunc = LogToFile;
    bool status = logFunc("Log Message");
}

private static bool LogToEventLog(string message) { /* log */}
private static bool LogToFile(string message) { /* log */}
~~~
