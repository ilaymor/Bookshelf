import { Component, OnInit } from '@angular/core';
import { CatalogService } from '../catalog.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit{
  catalogItems: any[] = [];

  constructor(private catalogService: CatalogService) { }

  ngOnInit(): void {
      this.GetCatalogItems()
  }

  GetCatalogItems(): void {
    this.catalogService.getCatalogItems().subscribe(
      (data: any[]) => {
        console.log("catalog items recieved")
        this.catalogItems = data;
      },
      (error: any) => console.error('Error fetching catalog items:', error)
    );
  }
}
