import { Component } from '@angular/core';

@Component({
    selector: 'top-menu',
    template: `
        <ul>
            <li><a href="#">Link#1</a></li>
            <li><a href="#">Link#2</a></li>
            <li><a href="#">Link#3</a></li>
            <li><a href="#">Link#4</a></li>
        </ul>
        `,
    styleUrls: ['app/navigation/top-menu.component.css']
})
export class TopMenuComponent { }