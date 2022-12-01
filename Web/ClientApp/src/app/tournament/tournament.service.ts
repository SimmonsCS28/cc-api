import { Injectable } from "@angular/core";
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Team } from '../team/team.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { Tournament } from "./tournament.model";

@Injectable({providedIn: 'root'})
export class TournamentService {
    private readonly APIEndpoint = environment.APIEndpoint;

    constructor(private http: HttpClient) {
    }

    getCurrentTournamentRegisteredTeams() {
        const url: string = this.APIEndpoint + 'tournament/' + '1' + '/teams';
        return this.http.get(url)
        .pipe(
            map((data: Team) => {
                return data;
            })
        )
    }

    createNewTournament(tournament: Tournament): Observable<Object> {
        const url: string = this.APIEndpoint + 'tournament/new-tournament/';
        return this.http.post(url, JSON.stringify(tournament), {
            headers: new HttpHeaders({
                'Access-Control-Allow-Origin' : 'https://www.cupcheckcancer.com',
                'Content-Type' : 'application/json'})
        })
    }

}
