import { Injectable } from "@angular/core";
import { Team } from './team.model';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment'


@Injectable({providedIn: 'root'})
export class TeamService {
    private readonly APIEndpoint = environment.APIEndpoint;

    constructor(private http: HttpClient) {
    }

    getAllTeams() {
        const url: string = this.APIEndpoint + 'team/';
        return this.http.get(url)
        .pipe(
            map((data: Team) => {
                return data;
            }), catchError( error =>  {
                return throwError('There was an error retrieving your team.');
            })
        );
    }

    getTeam(id: number) {
        const url: string = this.APIEndpoint + 'team/' + id.toString();
        return this.http.get(url)
        .pipe(
            map((data: Team) => {
                return data;
            }), catchError( error =>  {
                return throwError('There was an error retrieving your team.');
            })
        );
    }

    registerTeam(team: Team): Observable<Object>{
        const url: string = this.APIEndpoint + 'team/'
        console.log(JSON.stringify(team));
        return this.http.post(url, JSON.stringify(team), {
            headers: new HttpHeaders({
                'Access-Control-Allow-Origin' : 'https://www.cupcheckcancer.com',
                'Content-Type' : 'application/json'})
        });
    }
    
}