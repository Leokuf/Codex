* RXJS online book: http://xgrommx.github.io/rx-book/index.html
* Token Based Authentication: http://mherman.org/blog/2017/01/05/token-based-authentication-with-angular/#.Wm98PqinGHs
* Typescript Best Practices: https://www.gitbook.com/book/basarat/typescript/details
* Angular Drag and Drop: https://embed.plnkr.co/UOLION/
* Angular and ADAL Directory: https://spikesapps.wordpress.com/2017/07/27/securing-an-angular-application-with-azure-ad/

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
* Interface: 
* Enum:
* Module:

## Angular components

import { Component } from '@angular/core';  

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'];
})

export class AppComponent {
  title = 'app works!';
}

* HTML + CSS + Code = Component
* Import services
* Decorator is anything with an "@" in front of it. 
* Selector is the "tag" associated with the componetn.
* templateUrl defines HTML template
* styleUrls: Define styles
* .component.ts file is used for component.
* .component.spec.ts file is used for unit testing.



