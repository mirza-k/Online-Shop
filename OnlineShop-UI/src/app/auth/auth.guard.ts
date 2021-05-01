import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { UserService } from '../services/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardUser implements CanActivate {

  constructor(private userService:UserService, private router:Router){

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {

      if(this.userService.userLoggedIn()){
        return true;
      }
      else{
        this.router.navigate(['/user/login']);
        return false;
      }
  }
}
