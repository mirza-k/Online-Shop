import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtService } from 'src/app/services/jwt/jwt.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!:FormGroup;
  validRegistration:boolean=true;

  constructor(private userService: UserService, private router:Router, private jwtService:JwtService) { }

  ngOnInit(): void {
    if (this.userService.userLoggedIn()){
      this.router.navigate(['']);
    }

    this.registerForm = new FormGroup({
      'email': new FormControl(null),
      'username': new FormControl(null),
      'password': new FormControl(null),
      'userId': new FormControl('bb8e6b8c-c4e0-490d-85e6-b5bc48146939')
    });
  }

  onSubmit(){
    let registerUser = this.registerForm.value;
    this.userService.register(registerUser).subscribe((res: any) => {
      if (!res.success) {
        console.log(res);
        this.validRegistration = false;
      } else {
        localStorage.setItem('jwtToken', res.token);
        this.router.navigateByUrl('');
        
        //notify header component that user is logged in
        this.userService.userLoggedInNotification.emit();
      }
    })

  }
}
