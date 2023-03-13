import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";
import { Volunteer } from "./volunteer.model";

@Injectable({providedIn: 'root'})
export class VolunteerService {
    private readonly APIEndpoint = environment.APIEndpoint;

    constructor(private http: HttpClient) {
        
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