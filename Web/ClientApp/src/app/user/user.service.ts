import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { Volunteer } from "../volunteer/volunteer.model";

import { User } from "./user.model";


@Injectable({providedIn: 'root'})
export class UserService {
    private readonly APIEndpoint = environment.APIEndpoint;

    constructor(private http: HttpClient) {

    }

    getUser(id: number) {
        const url: string = this.APIEndpoint + 'user/' + id.toString();
        return this.http.get(url).pipe(
            map((data: User) => {
                return data;
            }), catchError( error => {
                return throwError('There was an error retrieving user with user ID ' + id.toString);
            })
        )
    }

    getUsers(ids: number[]) {
        let params = new HttpParams();
        for(let id of ids) {
            params = params.append('id', String(id));
        }
        const url: string = this.APIEndpoint + 'users/' ;
        return this.http.get(url, {params: params}).pipe(
            map((data: User[]) => {
                return data;
            }), catchError( error => {
                return throwError('There was an error retrieving users');
            })
        )
    }

    registerUser(){

    }

    registerVolunteer(volunteer: Volunteer): Observable<Object> {
        const url: string = this.APIEndpoint + 'volunteer/';
        console.log(JSON.stringify(volunteer));
        return this.http.post(url, JSON.stringify(volunteer), {
            headers: new HttpHeaders({
                'Access-Control-Allow-Origin' : 'https://www.cupcheckcancer.com',
                'Content-Type' : 'application/json'
            })
        });

    }
}