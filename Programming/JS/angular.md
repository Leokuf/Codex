# General Angular
* Angular4 overview: https://www.youtube.com/watch?v=KhzGSHNhnbI&t=687s
* RXJS online book: http://xgrommx.github.io/rx-book/index.html
* Token Based Authentication: http://mherman.org/blog/2017/01/05/token-based-authentication-with-angular/#.Wm98PqinGHs
* Typescript Best Practices: https://www.gitbook.com/book/basarat/typescript/details
* Angular Drag and Drop: https://embed.plnkr.co/UOLION/
* Angular and ADAL Directory: https://spikesapps.wordpress.com/2017/07/27/securing-an-angular-application-with-azure-ad/
* Angular Real World App Build: https://auth0.com/blog/real-world-angular-series-part-1/
* Angular 6 Application Architecture: https://medium.com/@cyrilletuzi/architecture-in-angular-projects-242606567e40
* Angular Authentication Using Route Guards: https://medium.com/@ryanchenkie_40935/angular-authentication-using-route-guards-bf7a4ca13ae3
* Route Guard Build Details: https://scotch.io/courses/routing-angular-2-applications/candeactivate
* Introduction to Reactive Programming **essential**: https://gist.github.com/staltz/868e7e9bc2a7b8c1f754

* Complex Guards: https://www.sparkbit.pl/angular-2-route-guards-real-life-example/ 
* Route Guards: https://blog.realworldfullstack.io/real-world-angular-part-6-3rs-rules-roles-routes-9e7de5a3ea8e
* Role Based Authorization in Angular: https://theinfogrid.com/tech/developers/angular/role-based-authorization-in-angular-route-guards

* Watching for click events: https://angular-2-training-book.rangle.io/handout/advanced-angular/directives/listening_to_an_element_host.html

* Component:
Component decorator allows you to mark a class as an Angular component and provide additional metadata that determines how the component should be processed, instantiated and used at runtime.
* Directive:
Directive decorator allows you to mark a class as an Angular directive and provide additional metadata that determines how the directive should be processed, instantiated and used at runtime.

Directives allow you to attach behavior to elements in the DOM..
* Pipe: 
A pipe takes in data as input and transforms it to a desired output
* Service: A function that allows you to access defined properties and methods.
* Class:
* Guard:
* Interface: https://www.typescriptlang.org/docs/handbook/interfaces.html
* Enum:
* Module:

Testing
* Services Test: https://blog.thoughtram.io/angular/2016/11/28/testing-services-with-http-in-angular-2.html
* Services Test (updated): https://offering.solutions/blog/articles/2017/10/02/testing-angular-2-http-service/
* More Services Testing: https://chariotsolutions.com/blog/post/testing-angular-2-0-x-services-http-jasmine-karma/
* More Services Testing: https://auth0.com/blog/angular-testing-in-depth-http-services/

Typescript
* Classes vs Interfaces: https://toddmotto.com/classes-vs-interfaces-in-typescript

## Angular components
```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',  
  templateUrl: './app.component.html',  
  styleUrls: ['./app.component.css'];  
}) 
  
export class AppComponent {  
  title = 'app works!';  
} 
```

* HTML + CSS + Code = Component
* Import services
* Decorator is anything with an "@" in front of it. 
* Selector is the "tag" associated with the componetn.
* templateUrl defines HTML template
* styleUrls: Define styles
* .component.ts file is used for component.
* .component.spec.ts file is used for unit testing.

### Referencing Object
```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',
  template: `  
  <p>Howdy!</p>  
  <p>{{ myObject.location }}</p>  
 ` ,  
  styleUrls: ['./app.component.css']  
})  

export class AppComponent {  

  myObject = {  
    gender: 'male',  
    age: 27,  
    location: 'USA'  
  }  

}
```

## Templating True / False Statements
```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',
  template: `  
  <p>Howdy!</p>  
  
  <div *ngIf="myArr; then tmpl1 else tmpl2"></div>
  
  <ng-template #tmpl1>Truth</ng-template>
  <ng-template #tmpl2>False</ng-template>
 ` ,  
  styleUrls: ['./app.component.css']  
})  

export class AppComponent {  

  myArr = false;

}
```

## Property Binding
* Passing data from the component class and setting a value of a given element in a view.
* Component class -> View

```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',
  template:   `
  <p>Howdy!</p>  
  
  //first way
 <img src = "{{ angularLogo }}">
 //second way
 <img [src] = "angularLogo">
 //third way
 <img bind-src="angularLogo">
  `,  
  styleUrls: ['./app.component.css']  
})  

export class AppComponent {  

  angularLogo = 'https://angular.io/angular.png'

}
```

```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',
  template:  ` 
  <p>Howdy!</p>  

  <button [disabled]="buttonStatus">My Button</button>
  ,  
  styleUrls: ['./app.component.css']  
})  

export class AppComponent {  

  buttonStatus = true;

}
```

## Event Binding
* Sends information from the view to the component class. Opposite from property binding.
* When you want to capture an event from the view, you wrap the event in question in parenthesis. 
* List of events that can be used. https://developer.mozilla.org/en-US/docs/Web/Events

```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',
  template: ` 
    <button (click)="myEvent($event)">My Button</button>
    <button (mouseenter)="myEvent($event)">My Button</button>
 ` ,  
  styleUrls: ['./app.component.css']  
})  

export class AppComponent {  

  myEvent(event) {
   console.log(event);
  }

}
```

### Class Binding
* Add, remove, or change CSS classes based on component logic.

```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',
  template: ` 
  
  <h1 [class]="titleClass">Hello!</h1>
  
 ` ,  
  styles: [`
    
    h1 {
      text-decoration:underline;
    }
    
    .red-title {
      color: red;
    }
  `]
})  

export class AppComponent {  

  titleClass = true

}
```
### Style Binding
* Change style attribute of a given HTML element.

```
import { Component } from '@angular/core';  

@Component({  
  selector: 'app-root',
  template: ` 
  
  <h1 [style.color]="titleStyle">Hello!</h1>
  <h2 [style.color]="titleStyle2 ? 'green' : 'pink'">Hello!</h2>
  
 ` ,  
  styles: [`
    
    h1 {
      text-decoration:underline;
    }
    
    .red-title {
      color: red;
    }
  `]
})  

export class AppComponent {  

  titleStyle = 'red';
  titleStyle2 = true;

}
```

## Services
- A function that allows you to access defined properties and methods.
- import in app.module file
- add to providers array in app.module

```
import { Injectable } from '@angular/core';

@Injectable()

export class DataService {
  //array
  constructor() { }
  cars = [
    'Ford', 'Chevrolet', 'Buick'
  ];
  //method
  myData() {
    return 'This is my data';
  }
  
}
```
* import into component
* dependency injection is done through Constructor

```
import { Component } from '@angular/core';  
import { DataService } from './data.service';

@Component({  
  selector: 'app-root',
  template: ` 
  
  <p>{{ someProperty }}</p>
  
 ` ,  
  styles: [`
    
    h1 {
      text-decoration:underline;
    }
    
    .red-title {
      color: red;
    }
  `]
})  

export class AppComponent {  

  constructor(private dataService:DataService) {
  
  }
  
  someProperty:string = '';
  
  ngOnInit() {
    console.log(this.dataService.cars);
    this.someProperty = this.dataService.myData();
  }
  
  titleStyle = 'red';
  titleStyle2 = true;

}
```
