import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GithubService {

  constructor(private http: HttpClient) { }

  public getUser(login: string): Observable<any> {
    return this.http.get(`https://api.github.com/users/${login}`);
  }

  public getUsers(): Observable<any> {
    return this.http.get(`https://api.github.com/users`);
  }

  public getPublicReposByUsername(username): Observable<any> {
    return this.http.get(`https://api.github.com/users/${username}/repos`);
  }

}
