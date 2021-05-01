import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';
import { Brand } from 'src/app/models/product/brand.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  baseUrl=environment.baseUrl;
  brandUrl="api/Brand";

  constructor(private http: HttpClient) { }

  get(): Observable<Brand[]>{
    return this.http.get<Brand[]>(`${this.baseUrl}/${this.brandUrl}`);
  }

}
