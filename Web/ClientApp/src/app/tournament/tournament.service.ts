import { Injectable } from "@angular/core";
import { map, catchError } from 'rxjs/operators';
import { Team } from '../team/team.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment'

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

}