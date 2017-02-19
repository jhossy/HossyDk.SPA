import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class GalleryListService {
    private serviceUrl = 'http://spa.hossy.dk/api/imageupload/';

    constructor(private http: Http) {}

    getGalleries(): Observable<Gallery[]> {
        return this.http.get(this.serviceUrl + 'GetGalleries')
            .map(this.extractData)
            .catch(this.handleError);
    }

    addGallery(galleryName: string): Observable<Response> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.post(this.serviceUrl + 'AddGallery', { name: galleryName }, { headers: headers })
            .map((res: Response) => res.json())
            //.subscribe(res => {
            //    console.log(res);
            //})
            .catch(this.handleError);
    }

    deleteGallery(galleryName: string): Observable<Response> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.post(this.serviceUrl + 'RemoveGallery', { name: galleryName }, { headers: headers })
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }

    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errorMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error() || JSON.stringify(body);
            errorMsg = `${error.status } - ${error.statusText || '' } ${err } `; 
        } else {
            errorMsg = error.message ? error.message : error.toString();
        }
        console.error(errorMsg);
        return Observable.throw(errorMsg);
    }
}

interface Gallery {
    name: string;
    noOfImages: number;
}