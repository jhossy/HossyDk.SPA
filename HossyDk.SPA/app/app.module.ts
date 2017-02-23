import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TopMenuComponent } from './navigation/top-menu.component';

import { GalleryComponent } from './gallery/gallery.component';
import { GalleryListComponent } from './gallery/gallery-list.component';
import { GalleryDragNDropComponent } from './gallery/gallery-drag-n-drop.component';

@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule],
    declarations: [AppComponent, GalleryComponent, GalleryListComponent, GalleryDragNDropComponent, TopMenuComponent],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }
