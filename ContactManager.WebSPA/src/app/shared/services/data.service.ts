import { Injectable } from '@angular/core';

import { Http, Response, RequestOptionsArgs, RequestMethod, Headers } from '@angular/http';

import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Injectable()
export class DataService{
    constructor(private http: Http){};

    get(url: string, params?:any): Observable<Response>{
        let options: RequestOptionsArgs = {};
        
        return this.http.get(url, options).map(
            (res: Response) => {
            return res;
            }
        ).catch(this.handleError);
    }

    post(url: string, data:any, params?:any): any{
        let options: RequestOptionsArgs = {};

        options.headers = new Headers();

        return this.http.post(url, data, options).subscribe(
            res => {
                return res;
            },
            err => {
                this.handleError(err);
            }
        );
    }

    put(url:string, data:any, params?:any): any{
        let options: RequestOptionsArgs = {};

        options.headers = new Headers();
        

        return this.http.put(url, data, options).subscribe(
            res => {
                return res;
            },
            err => {
                this.handleError(err);
            }
        );
    }

    delete(url:string, params?: any){
        let options: RequestOptionsArgs = {};
        
        options.headers = new Headers();
        
        this.http.delete(url, options).subscribe((res)=>{
            console.log('item deleted');
        })
    }

    private handleError(error:any){
        console.error('server error '+ error);

        if(error instanceof Response){
            let errorMessage = '';
            try{
                errorMessage = error.json();
            }catch(err){
                errorMessage = error.statusText;
            }

            return Observable.throw(errorMessage);
        }
        return Observable.throw(error || 'server error');
    }
}
