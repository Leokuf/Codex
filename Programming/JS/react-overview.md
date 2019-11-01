# React Overview
* Notes from a one-day study

## What is React

* df: An Open Source JavaScript library for creating rich interfaces

## Novel ideas
* Influence from functional programming
* One-way data flow
* Virtual DOM
* Vanilla JS for templating

* JavaScript components reference Inputs as Properties, Outputs as Callbacks.

## Advantages and Disadvantages
* Conceptual simplicty
* Speed
* Simple model for server-side rendering
* Disadvantage: Limited in scope, productivity, complex tooling

## React vs. Angular
* Angular has borrowed many ideas from React.
* React renders UI and handles events, nothing else.
* Angular is a complete UI framework
* React uses JavaScript for view logic
* Angular uses Custom "template expression" syntax
* React applications are written in JavaScript
* Angular applications are written in Typescript 

## What is a Component
* Fundamental unit of a React application
* Nested components === nested DOM nodes

## Rendering a Component 
````
import ReactDOM from 'react-dom';
import React from 'react';

function Hello(props) {
    return <h1>Hello at {props.now}</h1>;
}

ReactDOM.render(<Hello now={new Date().toISOString()} />,
    document.getElementById('root) 
);
````

## State
* Alternative component data container
* State is local, mutable data
* More complex
* Avoid using state when possible

````
/** state component** /

class ClickCounter extends React.Component {
    constructor(props) {
        super(props);
        this.state = {clicks: 0};
    }

    render() {
        return <div onClick={() =>
        { this.setState({clicks: this.state.clicks + 1}); }}>
        This div has been clicked {this.state.clicks} times.
        </div>;
    }
}
````

* Usually good to store state centrally.

### How to set State 

#### Previous state
````
{
    a: 1,
    b: 2
}
````

#### State change
````
this.setState({
    b: 3,
    c: 4
});
````

#### New state
````
{
    a: 1, 
    b: 3,
    c: 4
}
````

### Prop Validation
* Use PropTypes React package.
* TypeScript and Flow add static checking to React and provide sophisticated type systems to model your domain.


### Testing Components
* Logic should not be implemented in the user interface, but it can be beneficial to test React Components
* Enzyme is a good dependency for additional testing functionality

````
/** sample passing test **/
describe("When setting up testing", () => {
    it("should fail", () => {
        expect(1 + 1).toBe(2);
    });
});

/** sample failing test **/
describe("When setting up testing", () => {
    it("should fail", () => {
        expect(1 + 2).toBe(2);
    });
});
````

## What is JSX

* Allows us to include xml-like syntax inline in JavaScript.
* Each element is transformed into a JavaScript function call.
* You do not need to use JSX in React but it is recommended.

````
/** JSX **/
<Sum a={4} b={3}>

/** JavaScript **/
React.createElement(
    Sum,
    {a:4, b:3},
    null
)
````
### Props in JSX
* JSX attributes become component props 

````
<Hello now={new Date().toISOString()} />
<Hello now="Literal String Value" />
````

* Spread syntax: arrays and objects can be expanded in place by prefacing the value with 3 dots.
````
const props = {a: 4, b: 2};
const element = <Sum {...props } />;
````

* Props are how you pass data in and out of components, usually in response to an event.

### React Data Flow
* Data is passed down the heirarchy by passing as props. Data is passed back up the heirarchy by passing data as arguments to functions passed in as props.

### JSX vs HTML
````
/** JSX **/
<label 
    htmlFor="name"
    className="highlight"
    style={{
            backgroundColor: "yellow"
    }}
>
    Foo Bar 
</label>

/** HTML **/
<label
    for="name"
    class="highlight"
    style="background-color: yellow"
>
    Foo Bar
</label>
````
