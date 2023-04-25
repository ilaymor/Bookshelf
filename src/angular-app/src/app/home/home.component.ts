import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public homeText: string;
  public tiles = [
    {text: "Mystery", cols: 1, rows: 1, color: 'lightblue'},
    {text: "Adventure", cols: 1, rows: 1, color: 'lightblue'},
    {text: "Comedy", cols: 1, rows: 1, color: 'lightblue'},
    {text: "Romance", cols: 1, rows: 1, color: 'lightblue'},
    {text: "Biography", cols: 1, rows: 1, color: 'lightblue'},
    {text: "Explore more...", cols: 1, rows: 1, color: 'lightblue'}
  ]

  constructor() {
    this.homeText = 'Welcome to my app!'
  }
  ngOnInit(): void {
  }
}
