import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationResult } from 'src/app/models/user/authentication-result.model';
import { JwtService } from 'src/app/services/jwt/jwt.service';
import { UserService } from 'src/app/services/user/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  validLogin: boolean = true;

  constructor(private userService: UserService, private router: Router, private JwtService:JwtService) { }

  ngOnInit(): void {
    if (this.userService.userLoggedIn()){
      this.router.navigate(['']);
    }

    this.loginForm = new FormGroup({
      'username': new FormControl(null),
      'password': new FormControl(null),
      'userId': new FormControl('bb8e6b8c-c4e0-490d-85e6-b5bc48146939')
    });
  }

  onSubmit() {
    let loginUser = this.loginForm.value;
    this.userService.login(loginUser).subscribe((res: any) => {
      if (!res.success) {
        this.validLogin = res.success;
      } else {
        localStorage.setItem('jwtToken', res.token);
        this.router.navigateByUrl('');

        //notify header component that user is logged in
        this.userService.userLoggedInNotification.emit();
      }
    })
  }
}
