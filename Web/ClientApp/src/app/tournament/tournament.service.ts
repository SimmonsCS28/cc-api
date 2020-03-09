import { Injectable } from "@angular/core";
import { map, catchError } from 'rxjs/operators';
import { Team } from '../team/team.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class TournamentService {

    private readonly apiBaseUrl: string;
    private readonly localApiBaseUrl: string;

    constructor(private http: HttpClient) {
        this.apiBaseUrl = 'https://cupcheckcancer.azurewebsites.net/api/';
        this.localApiBaseUrl = 'http://localhost:56759/api/';
    }

    getCurrentTournamentRegisteredTeams() {
        const url: string = this.localApiBaseUrl + 'tournament/' + '1' + '/teams';
        return this.http.get(url)
        .pipe(
            map((data: Team) => {
                return data;
            })
        )
    }

}