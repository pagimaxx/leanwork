import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { GithubService } from './../../services/github.service';
import { ListModel } from 'src/app/models/github-list.model';
import { ReposModel } from './../../models/repos.model';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  public login: string;
  public user: ListModel;
  public repos: ReposModel;
  public listRepos: any;
  public erro: any;

  constructor(
    private githubService: GithubService,
    private route: ActivatedRoute
  ) {
    this.login = this.route.snapshot.params.login;
    this.getUser();
    this.getPublicReposByUsername();
  }

  ngOnInit() {

  }

  getUser() {
    this.githubService.getUser(this.login).subscribe(
      (data: ListModel) => {
        this.user = data;
      },
      (error: any) => {
        this.erro = error;
      }
    );
  }

  getPublicReposByUsername() {
    this.githubService.getPublicReposByUsername(this.login).subscribe(
      (data: any) => {
        this.repos = data.filter(d => d.private === false);
      },
      (error: any) => {
        this.erro = error;
      }
    );
  }

}
