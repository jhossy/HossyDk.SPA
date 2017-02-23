import { Component } from '@angular/core';

@Component({
    selector: 'my-gallery',
    template: `
    <div>
        <div class="col-md-4 round-corners">
            <gallery-list></gallery-list>
        </div>
        <div class="col-md-8 round-corners">
            <gallery-drag-n-drop></gallery-drag-n-drop>
        </div>        
    </div>
    `,
})
export class GalleryComponent {
    
}