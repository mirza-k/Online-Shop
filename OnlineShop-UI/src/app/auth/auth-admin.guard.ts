import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { JwtService } from '../services/jwt/jwt.service';

@Injectable({
  providedIn: 'root'
})
export class AuthAdminGuard implements CanActivate {

  constructor(private jwtService: JwtService, private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    let jwtToken: any = this.jwtService.decrypt(JSON.stringify(localStorage.getItem('jwtToken')));

    if (jwtToken != null) {
      let permittedRole = route.data['perrmittedRole'] as string;
      let userRole = jwtToken.Role;

      if (permittedRole == userRole) {
        return true;
      }
      else {
        this.router.navigate(['/authorization-failed']);
        return false;
      }
    }

    this.router.navigate(['/user/login']);
    return false;
  }
}
