import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CatalogService {
  private baseUrl = 'http://localhost:5003/gateway/Catalog'

  constructor(private http: HttpClient) { }

  getCatalogItems(): Observable<any> {
    return this.http.get(`${this.baseUrl}/items`);
  }

}
