import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
        <div>
            <div class="row round-corners spacing top-menu">
                <top-menu>Top menu here...</top-menu>
            </div>
            <div class="row spacing">                
                <my-gallery></my-gallery>
            </div>
        </div>`,
  styleUrls: ['app/app.component.css']
})
export class AppComponent  { }
