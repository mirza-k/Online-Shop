import { EventEmitter, Injectable } from '@angular/core';
import { User } from 'src/app/models/user/user.model';
import { environment } from 'src/environments/environment';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.baseUrl;
  userUrl = 'api/User';
  currentUserId!: string;
  token!: any;
  userLoggedInNotification = new EventEmitter();

  constructor(private http: HttpClient) { }

  login(user: User) {
    return this.http.post(`${this.baseUrl}/${this.userUrl}/login`, user);
  }

  register(user: User) {
    return this.http.post(`${this.baseUrl}/${this.userUrl}/register`, user);
  }

  logout() {
    localStorage.removeItem('jwtToken');
  }

  userLoggedIn() {
    if (localStorage.getItem('jwtToken') != null) {
      return true;
    }

    return false;
  }


}
