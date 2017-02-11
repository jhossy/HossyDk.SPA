import { Component } from '@angular/core';

@Component({
    selector: 'my-gallery',
    template: `
    <div>
        <div class="col-md-4 round-corners">
            <gallery-list></gallery-list>
        </div>
        <div class="col-md-8 round-corners">
            drag n drop area here
        </div>        
    </div>
    `,
})
export class GalleryComponent {
    
}