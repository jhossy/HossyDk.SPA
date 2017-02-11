import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { TopMenuComponent } from './navigation/top-menu.component';
import { GalleryComponent } from './gallery/gallery.component'
import { GalleryListComponent } from './gallery/gallery-list.component'

@NgModule({
    imports: [BrowserModule, HttpModule],
    declarations: [AppComponent, GalleryComponent, GalleryListComponent, TopMenuComponent],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }
