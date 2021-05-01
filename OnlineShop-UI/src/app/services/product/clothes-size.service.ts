import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';
import { ClothesSize } from 'src/app/models/product/clothes-size.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClothesSizeService {
  baseUrl=environment.baseUrl;
  clothesSizeUrl="api/ClothesSize";

  constructor(private http: HttpClient) { }

  get(): Observable<ClothesSize[]>{
    return this.http.get<ClothesSize[]>(`${this.baseUrl}/${this.clothesSizeUrl}`);
  }

  getById(id:number): Observable<ClothesSize>{
    return this.http.get<ClothesSize>(`${this.baseUrl}/${this.clothesSizeUrl}/${id}`);
  }
}