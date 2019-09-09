import { ListModel } from './../../models/github-list.model';
import { GithubService } from './../../services/github.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  public listUsers: any;
  public erro: any;

  constructor(private githubService: GithubService) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.githubService.getUsers().subscribe(
      (data: any) => {
        this.listUsers = data;
      },
      (error: any) => {
        this.erro = error;
      }
    );
  }

}
