import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { GalleryListService } from './gallery-list.service';

import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'gallery-list',
    template: `
        <div>
            <h2>Selected gallery: {{selectedGallery.name}}</h2>
            <ul *ngFor='let gallery of galleries; let i = index'>
                <li class="gallery-list-item" (click)='selectGallery(gallery)'>{{gallery.name}} ({{gallery.noOfImages}} images) <button (click)='deleteGallery(i)'>X</button></li>
            </ul>
            <button (click)='addGallery(gallery.value)'>Add gallery</button><br />
            <input type='text' placeholder='enter gallery name' #gallery />            
        </div>
    `,
    styleUrls: ['app/gallery/gallery-list.component.css'],
    providers: [GalleryListService]
})
export class GalleryListComponent implements OnInit {
    galleries: Gallery[];
    selectedGallery: Gallery;
    errorMessage: string;

    ngOnInit(): void {
        //this.getGalleries().subscribe(
        //    result => {
        //        this.galleries = result;
        //        this.selectedGallery = this.galleries[0];
        //    },
        //    error => this.errorMessage = <any>error
        //);
        this.getGalleries();
    }

    constructor(private galleryListService: GalleryListService) {
        this.galleries = [];
        this.selectedGallery = { name: '', noOfImages : 0 };
    }

    addGallery(galleryName: string) {
        var existingElm = this.galleries.filter(gallery => gallery.name.toLowerCase() == galleryName.toLowerCase());
        //if (galleryName !== '' && existingElm === undefined) {
        //    this.galleries.push({ name: galleryName, noOfImages: 0 });
        //} else {
        //    console.log('element with that name exists: ' + existingElm);
        //}
        console.log('...calling web api')
        this.galleryListService.addGallery(galleryName)
            .subscribe(
            res => console.log('res from list-component'),
            error => this.errorMessage = <any>error);
    }

    deleteGallery(idx: number) {
        this.galleries.splice(idx, 1);
    }

    selectGallery(gallery: Gallery) {
        console.log(gallery.name);
        this.selectedGallery = gallery;
    }

    getGalleries(): void {
        console.log('getGalleries...');
        //this.galleryNames = this.galleryListService.getGalleryNames().then(galleryNames => this.galleryNames = galleryNames);
        this.galleryListService.getGalleries()
            .subscribe(
            galleries => this.galleries = galleries,
            error => this.errorMessage = <any>error);
    }
}

interface Gallery {
    name: string;
    noOfImages: number;
}