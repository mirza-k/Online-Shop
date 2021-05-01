import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Color } from 'src/app/models/product/color.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ColorService {
  baseUrl = environment.baseUrl;
  colorUrl = 'api/Color';

  constructor(private http:HttpClient) { }

  get():Observable<Color[]>{
    return this.http.get<Color[]>(`${this.baseUrl}/${this.colorUrl}`);
  }

}
