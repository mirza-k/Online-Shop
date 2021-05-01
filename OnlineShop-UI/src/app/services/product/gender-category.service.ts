import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { genderCategory } from 'src/app/models/product/genderCategory.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenderCategoryService {
  baseUrl = environment.baseUrl;
  genderCategoryUrl = 'api/GenderCategory';

  constructor(private http: HttpClient) {
  }

  get(): Observable<genderCategory[]> {
    return this.http.get<genderCategory[]>(`${this.baseUrl}/${this.genderCategoryUrl}`);
  }
}
