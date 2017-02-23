import { Component } from '@angular/core';

@Component({
    selector: 'gallery-drag-n-drop',
    template: `
        <div class="container">
            <form class="box" ngSubmit="upload()" #uploadForm="ngForm" enctype="multipart/form-data">
                <div class="box__input">
                    <input class="box__file" type="file" name="files[]" id="file" data-multiple-caption="{count} files selected" multiple />
                    <label for="file">
                        <strong>Choose a file</strong>
                        <span class="box__dragndrop"> or drag it here</span>.
                    </label>
                    <button class="box__button" (click)="upload()">Upload</button>
                </div>
                <div class="box__uploading">Uploading&hellip;</div>
                <div class="box__success">Done!</div>
                <div class="box__error">Error! <span></span>.</div>
            </form>
        </div>
    `,
    styleUrls: ['app/gallery/gallery-drag-n-drop.component.css']
})

export class GalleryDragNDropComponent {

    upload() {
        console.log('clicked upload');
    }
}