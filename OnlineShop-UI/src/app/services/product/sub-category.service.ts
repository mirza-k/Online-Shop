import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { subCategory } from 'src/app/models/product/subCategory.model';

@Injectable({
  providedIn: 'root'
})
export class SubCategoryService {
  baseUrl = environment.baseUrl;
  subCategoryUrl = 'api/Subcategory';
  categoryUrl = 'Category';

  constructor(private http:HttpClient) { }

  getById(id:number):Observable<subCategory[]>{
    return this.http.get<subCategory[]>(`${this.baseUrl}/${this.subCategoryUrl}/${id}/${this.categoryUrl}`);
  }
}
